using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Reflection;
using Starts2000.Logging;
using Starts2000.Net.Buffer;
using Starts2000.Net.Session;

namespace Starts2000.Net.Pool
{
    public class BufferedSocketAsyncEventArgsPool : ISocketAsyncEventArgsPool, IDisposable
    {
        #region Fields

        ConcurrentQueue<SocketAsyncEventArgs> _saeaQueue;
#if NET45
        Queue<WeakReference<WeakSocketAsyncEventArgs>> _weakSaeaQueue;
#else
        Queue<WeakReference> _weakSaeaQueue;
#endif
        EventHandler<SocketAsyncEventArgs> _completedHandler;
        FixedBufferManager _fixedBufferManager;
        int _poolSize;
        int _bufferSize;
        int _allocatedCount;
        bool _disposed;
        readonly object _syncRoot = new object();

        static readonly ILogger _log = LogFactory.CreateLogger(MethodBase.GetCurrentMethod().ReflectedType);

        #endregion

        #region Properties

        public int AllocatedCount
        {
            get
            {
                lock (_syncRoot)
                {
                    return _allocatedCount;
                }
            }
        }

        public int PooledCount
        {
            get { return _saeaQueue.Count; }
        }

        public int WeakPooledCount
        {
            get
            {
                lock (_weakSaeaQueue)
                {
                    return _weakSaeaQueue.Count;
                }
            }
        }

        #endregion

        #region Constructors

        public BufferedSocketAsyncEventArgsPool(
            int poolSize, int bufferSize,
            EventHandler<SocketAsyncEventArgs> completedHanlder)
        {
            _poolSize = poolSize;
            _bufferSize = bufferSize;
            _saeaQueue = new ConcurrentQueue<SocketAsyncEventArgs>();
#if NET45
            _weakSaeaQueue = new Queue<WeakReference<WeakSocketAsyncEventArgs>>();
#else
            _weakSaeaQueue = new Queue<WeakReference>();
#endif
            _fixedBufferManager = new FixedBufferManager(_poolSize * bufferSize, bufferSize);
            _completedHandler = completedHanlder;
        }

        ~BufferedSocketAsyncEventArgsPool()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Methods

        public void Return(SocketAsyncEventArgs args)
        {
            if (args == null)
            {
                throw new ArgumentNullException("args");
            }

            WeakSocketAsyncEventArgs weakArgs = args as WeakSocketAsyncEventArgs;

            if (weakArgs != null)
            {
                lock (_weakSaeaQueue)
                {
#if NET45
                    _weakSaeaQueue.Enqueue(
                        new WeakReference<WeakSocketAsyncEventArgs>(weakArgs));
#else
                    _weakSaeaQueue.Enqueue(new WeakReference(weakArgs));
#endif
                }
            }
            else
            {
                _saeaQueue.Enqueue(args);
            }

            _log.Info("Return: " + ToString());
        }

        public SocketAsyncEventArgs Take()
        {
            _log.Info("Take: " + ToString());

            SocketAsyncEventArgs args = null;

            //优先使用固定缓存池
            if (_saeaQueue.TryDequeue(out args))
            {
                return args;
            }

            //如果固定缓存池没有了，而且分配的数量还没达到最大缓存数量，
            //则创建一个新的 SocketAsyncEventArgs。
            lock (_syncRoot)
            {
                if (_allocatedCount < _poolSize)
                {
                    args = Allocate(false);
                    _allocatedCount++;
                    return args;
                }
            }

            //如果固定缓存池已经使用完，且分配的数量已达到最大缓存数量，则查找弱引用缓存池。
            WeakSocketAsyncEventArgs weakArgs = null;

            lock (_weakSaeaQueue)
            {
                while (_weakSaeaQueue.Count > 0)
                {
#if NET45
                    if (_weakSaeaQueue.Dequeue().TryGetTarget(out weakArgs))
                    {
                        return weakArgs;
                    }
#else
                    WeakReference weakArgsRef = _weakSaeaQueue.Dequeue();
                    if (weakArgsRef.IsAlive)
                    {
                        weakArgs = weakArgsRef.Target as WeakSocketAsyncEventArgs;
                        return weakArgs;
                    }
#endif
                }
            }

            //如果前面的都没有了，则创建一个新的弱引用的 WeakSocketAsyncEventArgs。
            args = Allocate(true);
            return args;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;

                if (disposing)
                {
                    _saeaQueue = null;

                    lock (_weakSaeaQueue)
                    {
                        _weakSaeaQueue.Clear();
                        _weakSaeaQueue = null;
                    }

                    _completedHandler = null;
                }
            }
        }

        SocketAsyncEventArgs Allocate(bool weak)
        {
            SocketAsyncEventArgs args;

            if (weak)
            {
                args = new WeakSocketAsyncEventArgs();
                args.SetBuffer(new byte[_bufferSize], 0, _bufferSize);
            }
            else
            {
                args = new SocketAsyncEventArgs();
                _fixedBufferManager.SetBuffer(args);
            }

            args.UserToken = new AsyncSocketSessionToken();
            args.Completed += _completedHandler;

            return args;
        }

        public override string ToString()
        {
            return string.Format("AllocatedCount: {0}, PooledCount: {1}, WeakPooledCount: {2}",
                AllocatedCount.ToString(), PooledCount.ToString(), WeakPooledCount.ToString());
        }

        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}