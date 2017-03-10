using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Starts2000.Collections.Generic;
using Starts2000.Logging;

namespace Starts2000.Threading
{
    public sealed class CommandProcessor
    {
        #region Variables

        string _name;
        IList<Thread> _threads = new List<Thread>();
        LockFreeQueue<ICommand> _commands = new LockFreeQueue<ICommand>();
        int _commandsCount = 0;

        volatile bool _isRunning = false;

        int _busyThreads = 0;
        int _maxThreadsCount = Environment.ProcessorCount * 2;
        int _minThreadsCount = Environment.ProcessorCount;
        int _uselessThreadTimeout = 15000; // after 15 second inactivity, thread is removed

        long _totalExecutedCommands = 0;

        static readonly ILogger _log = LogFactory.CreateLogger(
            MethodBase.GetCurrentMethod().ReflectedType);

        #endregion

        #region Constructor

        public CommandProcessor(string name)
        {
            _name = name;
            AppDomain.CurrentDomain.ProcessExit += ProcessExit;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Returns the current number of threads used by this processor.
        /// </summary>
        public int ConcurrentThreads
        {
            get
            {
                lock (_threads)
                {
                    return _threads.Count;
                }
            }
        }

        /// <summary>
        /// Returns the total number of executed commands.
        /// </summary>
        public long TotalExecutedCommands
        {
            get { return _totalExecutedCommands; }
        }

        #endregion

        #region Start

        /// <summary>
        /// Start the processor
        /// </summary>
        public void Start()
        {
            _isRunning = true;

            for (int index = 0; index < _minThreadsCount; index++)
            {
                AddThreadToPool();
            }
        }

        #endregion

        #region Stop

        /// <summary>
        /// Stop the processor
        /// </summary>
        public void Stop()
        {
            if (!_isRunning)
            {
                return;
            }

            _isRunning = false;

            // Wake up all the threads
            lock (this)
            {
                Monitor.PulseAll(this);
            }

            // Force all the threads to stop
            lock (_threads)
            {
                foreach (Thread thread in _threads)
                {
                    thread.Abort(); // Violently stop the thread.
                }
            }

            _threads.Clear();
        }

        #endregion

        #region AddCommand

        /// <summary>
        /// Add a new command
        /// </summary>
        /// <param name="command">The command to execute</param>
        public void AddCommand(ICommand command)
        {
            _commands.Enqueue(command);

            Interlocked.Increment(ref _commandsCount);

            // Wakeup a processing thread
            lock (this)
            {
                Monitor.Pulse(this);
            }
        }

        /// <summary>
        /// Add a new command
        /// </summary>
        /// <param name="command">The command to execute</param>
        public void AddCommand(ICommand command, ThreadPriority threadPriority)
        {
            // NO MORE USED !!!!!! NO USE OF PRIORITY
            _commands.Enqueue(command);

            Interlocked.Increment(ref _commandsCount);

            // Wakeup a processing thread
            lock (this)
            {
                Monitor.Pulse(this);
            }
        }

        #endregion

        #region Processing

        void ThreadProc()
        {
            try
            {
                while (_isRunning)
                {
                    //---- Wait until we wake up this thread
                    if (_commandsCount < 1)
                    {
                        //-- Wait...
                        bool hasTimeOut = false;
                        lock (this)
                        {
                            hasTimeOut = !Monitor.Wait(this, _uselessThreadTimeout);
                        }

                        //-- The thread pool is NOT heavily used, remove this thread from the pool
                        if (hasTimeOut)
                        {
                            lock (_threads)
                            {
                                if (_threads.Count > _minThreadsCount)
                                {
                                    _threads.Remove(Thread.CurrentThread);
                                    return;
                                }
                            }
                            continue;
                        }
                    }

                    //---- Process at least one command, if fast enough can process several commands
                    Interlocked.Increment(ref _busyThreads);

                    //---- Thread pool is heavily used, add a thread to the pool
                    if (_busyThreads == _threads.Count)
                    {
                        AddThreadToPool();
                    }

                    ProcessAllCommands();
                    Interlocked.Decrement(ref _busyThreads);
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                _log.Error("", ex);
            }
        }

        /// <summary>
        /// To avoid too much context switching, we try to processing several commands.
        /// But this thread cannot execute during too much time.
        /// </summary>
        void ProcessAllCommands()
        {
            while (_isRunning)
            {
                //---- Get the next command
                ICommand command;

                if (!_commands.TryDequeue(out command))
                {
                    return; // No more commands
                }

                Interlocked.Decrement(ref _commandsCount);

                //---- Execute the command
                try
                {
                    command.Execute();
                }
                catch (Exception ex)
                {
                    _log.Error("", ex);
                }

                // Statistics
                Interlocked.Increment(ref _totalExecutedCommands);
            }
        }

        #endregion

        #region AddThreadToPool

        void AddThreadToPool()
        {
            lock (_threads)
            {
                if (_maxThreadsCount > -1 && _threads.Count >= _maxThreadsCount)
                {
                    return;
                }

                Thread newThread = new Thread(new ThreadStart(ThreadProc));
                newThread.Name = _name;
                newThread.IsBackground = true;
                newThread.Priority = ThreadPriority.Normal;
                newThread.Start();

                _threads.Add(newThread);
            }
        }

        #endregion

        #region ProcessExit

        void ProcessExit(object sender, EventArgs e)
        {
            Stop();
        }

        #endregion
    }
}
