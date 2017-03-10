using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using Starts2000.Logging;
using Starts2000.Net.Pool;
using Starts2000.Net.Util;

namespace Starts2000.Net.Session
{
    public class AsyncSocketSessionAcceptor : SessionAcceptorBase
    {
        #region Fields

        Socket _listenerSocket;
        readonly LinkedList<Socket> _pendingSockets;
        readonly Queue<Socket> _reuseSocketQueue;
        readonly SocketAsyncEventArgs _acceptSaea;
        readonly Timer _checkPendingSocketsTimer;

        const int CONNECTED_NO_DATA_TIMEOUT_MICROSECONDS = 120000;
        const int CONNECTED_NO_DATA_TIMEOUT_SECONDS = 120;

        static ILogger _log = LogFactory.CreateLogger(MethodBase.GetCurrentMethod().ReflectedType);

        #endregion

        #region CheckSessionCallBack

        public delegate void CheckSessionCallBack(ISession session);

        #endregion

        #region Constructors

        protected AsyncSocketSessionAcceptor()
        {
            _reuseSocketQueue = new Queue<Socket>();
            _pendingSockets = new LinkedList<Socket>();
            _acceptSaea = new SocketAsyncEventArgs();
            _acceptSaea.Completed += AcceptIoCompleted;
            base.SessionType = SessionType.Tcp;
            _checkPendingSocketsTimer = new Timer(CheckPendingSocketsTimeout,
                null, 0, CONNECTED_NO_DATA_TIMEOUT_MICROSECONDS);
        }

        public AsyncSocketSessionAcceptor(int port)
            : this(new IPEndPoint(IPAddress.Any, port))
        {
        }

        public AsyncSocketSessionAcceptor(IPEndPoint listenEndPoint)
            : this()
        {
            base.ListenEndPoint = listenEndPoint;
        }

        #endregion

        #region Public Methods

        public override void Start()
        {
            try
            {
                base.Started = true;
                _listenerSocket = SocketFactory.CreateSocket(base.SessionType);
                SetSocketOptions();
                _listenerSocket.Bind(base.ListenEndPoint);
                _listenerSocket.Listen(base.Backlog);
                DoAcceptAsync();
            }
            catch (Exception ex)
            {
                CaughtException(ex);
                throw new Exception("Async socket session acceptor start failed.", ex);
            }
        }

        public override void Close()
        {
            try
            {
                if (base.Started)
                {
                    base.Started = false;
                    _listenerSocket.Close();
                }

                base.ConnectedSessionLock.EnterReadLock();

                try
                {
                    foreach (KeyValuePair<IPEndPoint, ISession> pair in base.ConnectedSessions)
                    {
                        try
                        {
                            pair.Value.Close();
                        }
                        catch (Exception ex)
                        {
                            _log.Warn("Close connected session failed.", ex);
                        }
                    }
                }
                finally
                {
                    base.ConnectedSessionLock.ExitReadLock();
                }
            }
            catch (Exception ex)
            {
                CaughtException(ex);
            }
        }

        public void CheckSessionStatus(CheckSessionCallBack checkSession)
        {
            base.ConnectedSessionLock.EnterReadLock();

            try
            {
                foreach (KeyValuePair<IPEndPoint, ISession> pair in base.ConnectedSessions)
                {
                    try
                    {
                        checkSession(pair.Value);
                    }
                    catch
                    {
                    }
                }
            }
            finally
            {
                base.ConnectedSessionLock.ExitReadLock();
            }
        }

        #endregion

        #region Protected Methods

        internal void ProcessAccept(SocketAsyncEventArgs args)
        {
            try
            {
                if (args.SocketError == SocketError.Success)
                {
                    base.IncrementAcceptedCount();

                    AsyncTcpSession session = new AsyncTcpSession(args.AcceptSocket)
                    {
                        PacketDecoder = base.PacketDecoder,
                        PacketEncoder = base.PacketEncoder,
                    };

                    SessionAcceptedEventArgs sessionAcceptedEventArgs = new SessionAcceptedEventArgs(this, session);
                    session.Closed += base.SessionClosedEventHandler;
                    session.ExceptionCaught += base.SessionExceptionCaughtEventHandler;
                    AddConnectedSession(session);

                    lock (_pendingSockets)
                    {
                        _pendingSockets.Remove(args.AcceptSocket);
                    }

                    session.SocketReceiveAsync();
                    AcceptedSession(sessionAcceptedEventArgs);
                }
            }
            catch (Exception ex)
            {
                CaughtException(ex);
            }
            finally
            {
                args.AcceptSocket = null;

                try
                {
                    DoAcceptAsync();
                }
                catch (Exception ex)
                {
                    CaughtException(ex);
                }
            }
        }

        protected void CheckPendingSocketsTimeout(object arg)
        {
            try
            {
                LinkedList<Socket> list = new LinkedList<Socket>();

                lock (_pendingSockets)
                {
                    foreach (Socket socket in _pendingSockets)
                    {
                        try
                        {
                            if (WinSock2Wrapper.GetConnectTime(socket) >= CONNECTED_NO_DATA_TIMEOUT_SECONDS)
                            {
                                list.AddLast(socket);
                                _pendingSockets.Remove(socket);
                            }
                        }
                        catch
                        {
                        }
                    }
                }

                foreach (Socket socket in list)
                {
                    try
                    {
                        socket.Disconnect(true);
                    }
                    catch
                    {
                    }

                    lock (_reuseSocketQueue)
                    {
                        _reuseSocketQueue.Enqueue(socket);
                    }
                }
            }
            catch
            {
            }
        }

        //protected override void OnSessionClosed(object sender, SessionEventArgs e)
        //{
        //    base.OnSessionClosed(sender, e);

        //    try
        //    {
        //        _reuseSocketQueueLock.Enter();
        //        _reuseSocketQueue.Enqueue(((AsyncSocketSession)e.Session).Socket);
        //    }
        //    finally
        //    {
        //        _reuseSocketQueueLock.Exit();
        //    }
        //}

        protected override bool RemoveConnectedSession(ISession session)
        {
            bool remove = base.RemoveConnectedSession(session);

            if (remove)
            {
                lock (_reuseSocketQueue)
                {
                    _reuseSocketQueue.Enqueue(((AsyncSocketSession)session).Socket);
                }
            }

            return remove;
        }

        protected override void ReleaseManagedResources()
        {
            base.ReleaseManagedResources();

            _checkPendingSocketsTimer.Dispose();
            _acceptSaea.Dispose();

            lock(_reuseSocketQueue)
            {
                _reuseSocketQueue.Clear();
            }

            lock (_pendingSockets)
            {
                _pendingSockets.Clear();
            }
        }

        protected void SetSocketOptions()
        {
            _listenerSocket.SetSocketOption(
                SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, base.ReuseAddress);
        }

        #endregion

        #region Private Methods

        void DoAcceptAsync()
        {
            Socket acceptSocket = null;

            lock(_reuseSocketQueue)
            { 
                if (_reuseSocketQueue.Count > 0)
                {
                    acceptSocket = _reuseSocketQueue.Dequeue();
                }
            }
            
            if(acceptSocket == null)
            {
                acceptSocket = SocketFactory.CreateSocket(base.SessionType);
            }

            SocketAsyncEventArgs args = _acceptSaea;
            args.AcceptSocket = acceptSocket;
            args.UserToken = this;
            bool isAsync = true;

            try
            {
                isAsync = _listenerSocket.AcceptAsync(args);
            }
            catch(Exception ex)
            {
                args.AcceptSocket = null;
                CaughtException(ex);
            }

            if (!isAsync)
            {
                ProcessAccept(args);
            }

            lock (_pendingSockets)
            {
                _pendingSockets.AddLast(acceptSocket);
            }
        }

        void AcceptIoCompleted(object sender, SocketAsyncEventArgs e)
        {
            ProcessAccept(e);
        }

        #endregion
    }
}
