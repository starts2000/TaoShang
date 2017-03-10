using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using Starts2000.Logging;
using Starts2000.Net.Buffer;
using Starts2000.Net.Pool;
using Starts2000.Net.Session.Filter;
using Starts2000.Net.Session.Future;
using Starts2000.Net.Session.Packet;
using Starts2000.Net.Util;

namespace Starts2000.Net.Session
{
    public abstract class AsyncSocketSession : SessionBase
    {
        #region Fields

        readonly Socket _socket;
        readonly bool _reuseSocket;
        readonly SocketAsyncEventArgs _sendSaea;
        readonly SocketAsyncEventArgs _receiveSaea;
        readonly Queue<AsyncFuture> _sendQueue = new Queue<AsyncFuture>();
        readonly object _syncRoot = new object();

        protected const int SOCKET_TIMEOUT_SECONDS = 1;

        protected static readonly IPEndPoint AnyEndPoint = new IPEndPoint(IPAddress.Any, 0);
        static readonly ILogger _log = LogFactory.CreateLogger(MethodBase.GetCurrentMethod().ReflectedType);

        #endregion

        #region Properties

        internal Socket Socket
        {
            get { return _socket; }
        }

        protected Queue<AsyncFuture> SendQueue
        {
            get { return _sendQueue; }
        }

        protected bool ReuseSocket
        {
            get { return _reuseSocket; }
        }

        protected object SyncRoot
        {
            get { return _syncRoot; }
        }

        public override IPEndPoint LocalEndPoint
        {
            get
            {
                IPEndPoint baseLocalEndPoint = base.LocalEndPoint;

                if (baseLocalEndPoint != null)
                {
                    return baseLocalEndPoint;
                }

                lock (_syncRoot)
                {
                    if (baseLocalEndPoint == null)
                    {
                        IPEndPoint localEndPoint = _socket.LocalEndPoint as IPEndPoint;

                        if (localEndPoint == null)
                        {
                            return new IPEndPoint(IPAddress.Any, 0);
                        }

                        if (!IPAddress.Any.Equals(localEndPoint.Address))
                        {
                            baseLocalEndPoint = localEndPoint;
                            return localEndPoint;
                        }

                        if (base.RemoteEndPoint == null ||
                            IPAddress.Any.Equals(RemoteEndPoint.Address))
                        {
                            return localEndPoint;
                        }

                        baseLocalEndPoint = WinSock2Wrapper.QueryRoutingInterface(
                            _socket, base.RemoteEndPoint);
                    }

                    return baseLocalEndPoint;
                }
            }
            set
            {
                if (base.IsOpened)
                {
                    throw new InvalidOperationException("Session already opened.");
                }

                if (value != null)
                {
                    _socket.Bind(value);
                }
            }
        }

        #endregion

        #region Constructors

        protected AsyncSocketSession(Socket socket, bool reuseSocket)
            : base(socket.ProtocolType == ProtocolType.Tcp ? SessionType.Tcp : SessionType.Udp)
        {
            if (socket == null)
            {
                throw new ArgumentNullException("socket");
            }

            _socket = socket;
            _reuseSocket = reuseSocket;
            base.RemoteEndPoint = socket.RemoteEndPoint as IPEndPoint;
            _sendSaea = SocketAsyncEventArgsPoolManager.Instance.SendSaeaPool.Take();
            _receiveSaea = SocketAsyncEventArgsPoolManager.Instance.ReceiveSaeaPool.Take();
            (_sendSaea.UserToken as AsyncSocketSessionToken).Session = this;
            (_receiveSaea.UserToken as AsyncSocketSessionToken).Session = this;
        }

        protected AsyncSocketSession(SessionType sessionType, 
            IPEndPoint remoteEndPoint, bool reuseSocket)
            : base(sessionType, remoteEndPoint)
        {
            _socket = SocketFactory.CreateSocket(sessionType);
            _reuseSocket = reuseSocket;
            _sendSaea = SocketAsyncEventArgsPoolManager.Instance.SendSaeaPool.Take();
            _receiveSaea = SocketAsyncEventArgsPoolManager.Instance.ReceiveSaeaPool.Take();
            (_sendSaea.UserToken as AsyncSocketSessionToken).Session = this;
            (_receiveSaea.UserToken as AsyncSocketSessionToken).Session = this;
        }

        #endregion

        #region Methods

        public override IFuture Open()
        {
            if (base.SessionState != SessionState.Initial && SessionState != SessionState.Closed)
            {
                throw new InvalidOperationException("This session already started.");
            }

            if (base.RemoteEndPoint == null)
            {
                throw new InvalidOperationException("Remote endpoint could not be null.");
            }

            AsyncFuture future;

            lock (_syncRoot)
            {
                if (base.IsOpened)
                {
                    throw new InvalidOperationException("This session already started.");
                }

                future = new AsyncFuture(this);

                try
                {
                    base.SessionState = SessionState.Opening;
                    InternalOpen(future);
                }
                catch (ObjectDisposedException)
                {
                    future.IsSucceeded = false;
                    //base.SessionCaughtException(ex);
                }
                catch (Exception ex)
                {
                    SafeClose();
                    base.SessionCaughtException(ex);
                    base.SessionState = SessionState.Initial;
                    future.IsSucceeded = false;
                }

                return future;
            }
        }

        public override IFuture Close()
        {
            AsyncFuture future = new AsyncFuture(this); 

            if (!base.IsOpened)
            {
                future.IsSucceeded = false;
                return future;
            }

            lock (_syncRoot)
            {
                if (!base.IsOpened)
                {
                    throw new InvalidOperationException("This session not started.");
                }

                base.SessionState = SessionState.Closing;

                try
                {
                    InternalClose();
                    future.IsSucceeded = true;
                }
                catch (ObjectDisposedException)
                {
                    future.IsSucceeded = false;
                    //base.SessionCaughtException(ex);
                }
                catch (Exception ex)
                {
                    future.IsSucceeded = false;
                    base.SessionCaughtException(ex);
                    SafeClose();
                }
                finally
                {
                    lock (_sendQueue)
                    {
                        foreach (var sendFuture in _sendQueue)
                        {
                            sendFuture.IsSucceeded = false;
                        }

                        _sendQueue.Clear();
                    }

                    base.SessionState = SessionState.Closed;
                    base.SessionClosed();
                }

                return future;
            }
        }

        protected override IFuture Send(object obj, IPacket packet)
        {
            AsyncFuture item = new AsyncFuture(this);
            item.AssociatedObject = obj;
            item.AssociatedPacket = packet;

            if(!base.IsOpened)
            {
                item.IsSucceeded = false;
                return item;
            }

            lock (_sendQueue)
            {
                _sendQueue.Enqueue(item);

                if (_sendQueue.Count > 1)
                {
                    return item;
                }

                SendFirstOfQueue();
            }

            return item;
        }

        protected void SafeClose()
        {
            if(_socket != null)
            {
                try
                {
                    _socket.Shutdown(SocketShutdown.Both);
                }
                catch(ObjectDisposedException)
                {
                }
                catch
                {
                    _socket.Close(SOCKET_TIMEOUT_SECONDS);
                }
            }
        }

        protected bool CheckSendOrReceiveSuccess(SocketAsyncEventArgs args)
        {
            return args.SocketError == SocketError.Success && args.BytesTransferred != 0;
        }

        internal void SocketSendAsync(IPacket packet, AsyncFuture future)
        {
            if (base.IsOpened)
            {
                SocketAsyncEventArgs args = _sendSaea;
                args.SetBuffer(packet.Buffer.ByteArray, packet.Buffer.Position, packet.Buffer.Remaining);

                var token = args.UserToken as AsyncSocketSessionToken;
                token.Future = future;
                bool isAsync = true;

                try
                {
                    isAsync = DoSocketSendAsync(args);
                }
                catch (SocketException ex)
                {
                    args.SetBuffer(null, 0, 0);
                    SendCompletedProcess(future, false);
                    base.SessionCaughtException(ex);
                    Close();
                }
                catch (ObjectDisposedException)
                {
                    args.SetBuffer(null, 0, 0);
                    SendCompletedProcess(future, false);
                    //base.SessionCaughtException(ex);
                }
                catch (Exception ex)
                {
                    args.SetBuffer(null, 0, 0);
                    SendCompletedProcess(future, false);
                    base.SessionCaughtException(ex);
                }

                if (!isAsync)
                {
                    ProcessSend(args);
                }
            }
        }

        internal void SocketReceiveAsync()
        {
            if(base.IsOpened)
            {
                SocketAsyncEventArgs args = _receiveSaea;
                bool isAsync = true;

                try
                {
                    isAsync = DoSocketReceiveAsync(args);
                }
                catch (SocketException ex)
                {
                    base.SessionCaughtException(ex);
                    Close();
                }
                catch (Exception ex)
                {
                    base.SessionCaughtException(ex);
                }

                if(!isAsync)
                {
                    ProcessReceive(args);
                }
            }
        }

        protected abstract bool DoSocketSendAsync(SocketAsyncEventArgs args);

        protected abstract bool DoSocketReceiveAsync(SocketAsyncEventArgs args);

        internal void ProcessSend(SocketAsyncEventArgs args)
        {
            try
            {
                DoProcessSend(args);
            }
            catch (Exception ex)
            {
                base.SessionCaughtException(ex);
            }
        }

        internal void ProcessReceive(SocketAsyncEventArgs args)
        {
            try
            {
                IPacket packet = DoProcessReceive(args);
                SocketReceiveAsync();

                if (packet != null)
                {
                    base.GetSessionFilterChain(FilterChainMode.Receive).PacketReceived(packet);
                }
            }
            catch (Exception ex)
            {
                base.SessionCaughtException(ex);
            }
        }

        protected virtual void DoProcessSend(SocketAsyncEventArgs args)
        {
            if (!base.IsOpened)
            {
                return;
            }

            if (!CheckSendOrReceiveSuccess(args))
            {
                Close();
                return;
            }

            var sendToken = args.UserToken as AsyncSocketSessionToken;
            AsyncFuture sendFuture = sendToken.Future;

            if (sendFuture != null)
            {
                IPacket associatedPacket = sendFuture.AssociatedPacket;

                try
                {
                    int sendCount = args.BytesTransferred;

                    try
                    {
                        IBuffer content = associatedPacket.Buffer;
                        content.Position += sendCount;
                    }
                    catch (Exception ex)
                    {
                        if (_log.IsWarnEnabled)
                        {
                            _log.Warn("Change packet content postion failed.", ex);
                        }
                    }

                    if (associatedPacket.Buffer.Remaining > 0 && base.SessionType != SessionType.Udp)
                    {
                        SocketSendAsync(associatedPacket, sendFuture);
                    }
                    else
                    {
                        SendCompletedProcess(sendFuture, true);
                    }
                }
                catch (Exception ex)
                {
                    _log.Fatal("DoProcessSend failed.", ex);
                    SendCompletedProcess(sendFuture, false);
                    base.SessionCaughtException(ex);
                }
            }
        }

        protected virtual IPacket DoProcessReceive(SocketAsyncEventArgs args)
        {
            if (!base.IsOpened)
            {
                return null;
            }

            if (!CheckSendOrReceiveSuccess(args))
            {
                Close();
                return null;
            }

            int receiveCount = args.BytesTransferred;
            IBuffer buffer = BufferFactory.GetBuffer(receiveCount);
            System.Buffer.BlockCopy(args.Buffer, args.Offset, buffer.ByteArray, 0, receiveCount);
            return new DefaultPacket(buffer, RemoteEndPoint);
        }

        protected abstract void InternalOpen(IFuture future);
        protected abstract void InternalClose();

        protected override void ReleaseManagedResources()
        {
            try
            {
                if(!_reuseSocket && _socket != null)
                {
                    _socket.Dispose();
                }

                var sendToken = _sendSaea.UserToken as AsyncSocketSessionToken;
                sendToken.Session = null;
                sendToken.Future = null;
                (_receiveSaea.UserToken as AsyncSocketSessionToken).Session = null;
                SocketAsyncEventArgsPoolManager.Instance.SendSaeaPool.Return(_sendSaea);
                SocketAsyncEventArgsPoolManager.Instance.ReceiveSaeaPool.Return(_receiveSaea);
            }
            catch(Exception ex)
            {
                _log.Error("ReleaseManagedResources failed.", ex);
            }

            base.ReleaseManagedResources();
        }

        void SendFirstOfQueue()
        {
            if (_sendQueue.Count > 0)
            {
                try
                {
                    AsyncFuture future = null;

                    lock (_sendQueue)
                    {
                        if (_sendQueue.Count <= 0)
                        {
                            return;
                        }

                        future = _sendQueue.Peek();
                    }

                    if (future != null)
                    {
                        IPacket associatedPacket = future.AssociatedPacket;
                        base.GetSessionFilterChain(new SendOperateFilter(this, future),
                            FilterChainMode.Send).PacketSend(associatedPacket);
                    }
                }
                catch (Exception ex)
                {
                    base.SessionCaughtException(ex);
                    throw;
                }
            }
        }

        void SendCompletedProcess(AsyncFuture sendFuture, bool successed)
        {
            lock (_sendQueue)
            {
                if (_sendQueue.Count > 0)
                {
                    _sendQueue.Dequeue();
                }
            }

            if(successed)
            {
                SendFirstOfQueue();
            }

            sendFuture.IsSucceeded = successed;
            base.GetSessionFilterChain(
               FilterChainMode.Send).PacketSent(sendFuture.AssociatedPacket);
            base.GetSessionFilterChain(
                FilterChainMode.Send).ObjectSent(sendFuture.AssociatedObject);
        }

        #endregion

        #region SendOperateFilter Class

        protected class SendOperateFilter : SessionFilterAdapter
        {
            #region Fields

            protected readonly AsyncFuture _future;
            protected readonly AsyncSocketSession _parentSession;

            #endregion

            #region Constructor

            public SendOperateFilter(AsyncSocketSession session, AsyncFuture future)
            {
                _future = future;
                _parentSession = session;
            }

            #endregion

            #region Methods

            public override void PacketSend(ISessionFilterChain filterChain, IPacket packet)
            {
                if (packet.Buffer.Remaining > 0)
                {
                    _parentSession.SocketSendAsync(packet, _future);
                }

                base.PacketSend(filterChain, packet);
            }

            #endregion
        }

        #endregion
    }
}