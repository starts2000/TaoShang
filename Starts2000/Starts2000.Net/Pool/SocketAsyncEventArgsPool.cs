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
    /// <summary>
    /// <see cref="SocketAsyncEventArgs"/>对象缓存池。
    /// </summary>
    public class SocketAsyncEventArgsPool : ISocketAsyncEventArgsPool, IDisposable
    {
        #region Fields

        ConcurrentQueue<SocketAsyncEventArgs> _saeaQueue;
#if NET45
        Queue<WeakReference<WeakSocketAsyncEventArgs>> _weakSaeaQueue;
#else
        Queue<WeakReference> _weakSaeaQueue;
#endif
        EventHandler<SocketAsyncEventArgs> _completedHandler;
        int _poolSize;
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

        /// <summary>
        /// 初始化一个<see cref="SocketAsyncEventArgsPool"/>对象。
        /// </summary>
        /// <param name="poolSize">缓存池容量。</param>
        /// <param name="completedHandler">
        /// 创建<see cref="SocketAsyncEventArgs" />对象的方法。</param>
        public SocketAsyncEventArgsPool(
            int poolSize, EventHandler<SocketAsyncEventArgs> completedHandler)
        {
            _poolSize = poolSize;
            _completedHandler = completedHandler;
            _saeaQueue = new ConcurrentQueue<SocketAsyncEventArgs>();
#if NET45
            _weakSaeaQueue = new Queue<WeakReference<WeakSocketAsyncEventArgs>>();
#else
            _weakSaeaQueue = new Queue<WeakReference>();
#endif
        }

        ~SocketAsyncEventArgsPool()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Methods

        /// <summary>
        /// 将使用完成的<see cref="SocketAsyncEventArgs"/>对象回收到缓存池。
        /// </summary>
        /// <param name="args">需要缓存的<see cref="SocketAsyncEventArgs"/>对象。</param>
        public void Return(SocketAsyncEventArgs args)
        {
            if (args == null)
            {
                throw new ArgumentNullException("args");
            }

            WeakSocketAsyncEventArgs weakArgs = args as WeakSocketAsyncEventArgs;

            //如果是临时创建的弱引用对象，回收到弱引用对象缓存池。否则，回收到固定的缓存池。
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

        /// <summary>
        /// 从缓存池中获取一个<see cref="SocketAsyncEventArgs"/>，
        /// 如果缓存池中的对象已经用完，则创建一个新的<see cref="SocketAsyncEventArgs"/>。
        /// </summary>
        /// <returns>一个<see cref="SocketAsyncEventArgs"/>对象。</returns>
        public SocketAsyncEventArgs Take()
        {
            _log.Info("Take: " + ToString());

            SocketAsyncEventArgs args;

            //优先使用固定缓存池。
            if (_saeaQueue.TryDequeue(out args))
            {
                return args;
            }

            lock (_syncRoot)
            {
                if (_allocatedCount < _poolSize)
                {
                    args = Allocate(false);
                    _allocatedCount++;
                    return args;
                }
            }

            //如果固定缓存池已经使用完，则查找弱引用缓存池，如果缓存池的没有，则创建一个新的。
            lock (_weakSaeaQueue)
            {
                WeakSocketAsyncEventArgs weakArgs = null;

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

            return Allocate(true);
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
            SocketAsyncEventArgs args = weak ?
                new WeakSocketAsyncEventArgs() : new SocketAsyncEventArgs();
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

        /// <summary>
        /// 清理缓存的资源。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}
