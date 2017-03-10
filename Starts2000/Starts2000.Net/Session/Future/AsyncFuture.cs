using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Starts2000.Logging;
using Starts2000.Net.Session.Packet;
using Starts2000.Net.Util;

namespace Starts2000.Net.Session.Future
{
    public sealed class AsyncFuture : IFuture
    {
        #region Fields

        object _associatedObject;
        IPacket _associatedPacket;
        IAsyncResult _asyncResult;
        bool _isCompleted;
        bool _isSucceed;
        object _tag;

        readonly ISession _session;
        readonly List<WaitHandle> _waitHandles;

        static readonly ILogger _log = LogFactory.CreateLogger(MethodBase.GetCurrentMethod().ReflectedType);

        #endregion

        #region Events

        public event EventHandler<FutureCompletedEventArgs> FutureCompleted;

        #endregion

        #region Properties

        internal object AssociatedObject
        {
            get { return _associatedObject; }
            set { _associatedObject = value; }
        }

        internal IPacket AssociatedPacket
        {
            get { return _associatedPacket; }
            set { _associatedPacket = value; }
        }

        public IAsyncResult AsyncResult
        {
            get { return _asyncResult; }
            set
            {
                if (_asyncResult == null && _asyncResult != value)
                {
                    _asyncResult = value;
                    _waitHandles.Add(_asyncResult.AsyncWaitHandle);
                }
            }
        }

        public bool IsCompleted
        {
            get
            {
                if (_asyncResult != null)
                {
                    return _asyncResult.IsCompleted;
                }

                return _isCompleted;
            }
            set
            {
                if (_asyncResult != null)
                {
                    throw new InvalidOperationException();
                }

                _isCompleted = value;
            }
        }

        public bool IsSucceeded
        {
            get { return _isSucceed; }
            set
            {
                _isSucceed = value;
                FireFutureCompletedEvent();
            }
        }

        public ISession Session
        {
            get { return _session; }
        }

        public object Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        #endregion

        #region Methods

        public AsyncFuture(ISession session)
        {
            _session = session;
            _isSucceed = false;
            _waitHandles = new List<WaitHandle>();
        }

        public void AddWaitHandle(WaitHandle waitHandle)
        {
            ValidateHelper.CheckNullArgument("waitHandle", waitHandle);

            if (_waitHandles.IndexOf(waitHandle) < 0)
            {
                _waitHandles.Add(waitHandle);
            }
        }

        public bool Complete()
        {
            return Complete(20000);
        }

        public bool Complete(int timeout)
        {
            if (_isCompleted)
            {
                return true;
            }

            if (_waitHandles.Count == 0)
            {
                return false;
            }

            try
            {
                return WaitHandle.WaitAll(_waitHandles.ToArray(), timeout, true);
            }
            catch (AbandonedMutexException exception)
            {
                _log.Error("The wait terminated because a thread exited without releasing a mutex.", exception);
                return true;
            }
            catch (Exception exception)
            {
                _log.Error("Future complete failed.", exception);
                return false;
            }
        }

        void FireFutureCompletedEvent()
        {
            if (FutureCompleted != null)
            {
                try
                {
                    FutureCompleted(this, new FutureCompletedEventArgs(this));
                }
                catch
                {
                }
            }
        }

        #endregion
    }
}
