using System;
using System.Net;
using System.Net.Sockets;
using Starts2000.Net.Session.Future;
using Starts2000.Net.Util;

namespace Starts2000.Net.Session
{
    public class AsyncTcpSession : AsyncSocketSession
    {
        #region Fields

        SocketAsyncEventArgs _connectSaea;

        #endregion

        #region Constructors

        public AsyncTcpSession(IPEndPoint remoteIPEndPoint,
            bool keepAlive, uint time, uint interval, bool reuseSocket = true)
            : this(AnyEndPoint, remoteIPEndPoint, keepAlive, time, interval, reuseSocket)
        {
            if (keepAlive)
            {
                WinSock2Wrapper.SetKeepAlive(base.Socket, true, time, interval);
            }

            CreateConnectSaea();
        }

        public AsyncTcpSession(IPEndPoint localIPEndPoint, IPEndPoint remoteIPEndPoint,
            bool keepAlive, uint time, uint interval, bool reuseSocket = true)
            : base(SessionType.Tcp, remoteIPEndPoint, reuseSocket)
        {
            base.LocalEndPoint = localIPEndPoint;

            if (keepAlive)
            {
                WinSock2Wrapper.SetKeepAlive(base.Socket, true, time, interval);
            }
            CreateConnectSaea();
        }

        public AsyncTcpSession(Socket socket, bool reuseSocket = true)
            : base(socket, reuseSocket)
        {
            base.SessionState = SessionState.Opened;
            CreateConnectSaea();
        }

        #endregion

        #region Methods

        protected override void InternalOpen(IFuture future)
        {
            _connectSaea.UserToken = future;

            try
            {
                if (!base.Socket.ConnectAsync(_connectSaea))
                {
                    ProcessConnect(_connectSaea);
                }
            }
            catch(Exception ex)
            {
                ((AsyncFuture)future).IsSucceeded = false;
                base.SessionCaughtException(ex);
            }
        }

        protected override void InternalClose()
        {
            try
            {
                base.Socket.Shutdown(SocketShutdown.Both);

                if (base.ReuseSocket)
                {
                    base.Socket.Disconnect(true);
                }
                else
                {
                    base.Socket.Close();
                }
            }
            catch (NullReferenceException) //Microsoft Bug, Socket.Disconnect
            {
            }
        }

        protected override bool DoSocketSendAsync(SocketAsyncEventArgs args)
        {
            return base.Socket.SendAsync(args);
        }

        protected override bool DoSocketReceiveAsync(SocketAsyncEventArgs args)
        {
            return base.Socket.ReceiveAsync(args);
        }

        protected override void ReleaseManagedResources()
        {
            if (_connectSaea != null)
            {
                _connectSaea.Dispose();
            }
            base.ReleaseManagedResources();
        }

        void CreateConnectSaea()
        {
            _connectSaea = new SocketAsyncEventArgs();
            _connectSaea.RemoteEndPoint = base.RemoteEndPoint;
            _connectSaea.Completed += ConnectIOCompleted;
        }

        void ConnectIOCompleted(object sender, SocketAsyncEventArgs e)
        {
            switch(e.LastOperation)
            {
                case SocketAsyncOperation.Connect:
                    ProcessConnect(e);
                    break;
            }
        }

        void ProcessConnect(SocketAsyncEventArgs args)
        {
            AsyncFuture future = args.UserToken as AsyncFuture;

            if(args.SocketError == SocketError.Success)
            {
                lock (base.SyncRoot)
                {
                    base.SessionState = SessionState.Opened;
                    base.SocketReceiveAsync();
                    future.IsSucceeded = true;
                }
            }
            else
            {
                lock (base.SyncRoot)
                {
                    base.SessionState = SessionState.Initial;
                    future.IsSucceeded = false;
                }
            }
        }

        #endregion
    }
}
