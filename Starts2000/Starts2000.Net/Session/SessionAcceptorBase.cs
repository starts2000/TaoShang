using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using Starts2000.Logging;
using Starts2000.Net.Session.Packet;

namespace Starts2000.Net.Session
{
    public abstract class SessionAcceptorBase : DisposableBase, ISessionAcceptor
    {
        #region Fields

        int _acceptedCount;
        int _backLog;
        IPEndPoint _listenEndPoint;
        IPacketDecoder _packetDecoder;
        IPacketEncoder _packetEncoder;
        bool _reuseAddress;
        SessionType _sessionType;
        bool _started;

        readonly ReaderWriterLockSlim _connectedSessionLock = new ReaderWriterLockSlim();
        readonly IDictionary<IPEndPoint, ISession> _connectedSessions = new Dictionary<IPEndPoint, ISession>();
        
        readonly EventHandler<SessionEventArgs> _sessionClosedEventHandler;
        readonly EventHandler<ExceptionEventArgs> _sessionExceptionCaughtEventHandler;

        //protected const int READER_WRITER_LOCK_TIMEOUT = 1000;
        static readonly ILogger _log = LogFactory.CreateLogger(MethodBase.GetCurrentMethod().ReflectedType);

        #endregion

        #region Events

        public event EventHandler<ExceptionEventArgs> ExceptionCaught;
        public event EventHandler<SessionAcceptedEventArgs> SessionAccepted;
        
        #endregion

        #region Constructors

        protected SessionAcceptorBase()
        {
            _sessionClosedEventHandler = OnSessionClosed;
            _sessionExceptionCaughtEventHandler = OnSessionCaughtException;
        }

        #endregion

        #region Properties

        public int AcceptedCount
        {
            get { return _acceptedCount; }
        }

        public int Backlog
        {
            get { return _backLog; }
            set
            {
                if (Started)
                {
                    throw new InvalidOperationException(
                        "Can't set listen backlog after acceptor started");
                }

                _backLog = value;
            }
        }

        public IPEndPoint ListenEndPoint
        {
            get { return _listenEndPoint; }
            set
            {
                if (_listenEndPoint == null)
                {
                    if (Started)
                    {
                        throw new InvalidOperationException(
                            "Can't set listen address after acceptor started");
                    }

                    _listenEndPoint = value;
                }
            }
        }

        public IPacketDecoder PacketDecoder
        {
            get { return _packetDecoder; }
            set { _packetDecoder = value; }
        }

        public IPacketEncoder PacketEncoder
        {
            get { return _packetEncoder; }
            set { _packetEncoder = value; }
        }

        public bool ReuseAddress
        {
            get { return _reuseAddress; }
            set { _reuseAddress = value; }
        }

        public SessionType SessionType
        {
            get { return _sessionType; }
            protected set { _sessionType = value; }
        }

        public bool Started
        {
            get { return _started; }
            protected set { _started = value; }
        }

        protected ReaderWriterLockSlim ConnectedSessionLock
        {
            get { return _connectedSessionLock; }
        }

        public IDictionary<IPEndPoint, ISession> ConnectedSessions
        {
            get { return _connectedSessions; }
        }

        protected EventHandler<SessionEventArgs> SessionClosedEventHandler
        {
            get { return _sessionClosedEventHandler; }
        }

        protected EventHandler<ExceptionEventArgs> SessionExceptionCaughtEventHandler
        {
            get { return _sessionExceptionCaughtEventHandler; }
        }

        #endregion

        #region Methods

        public abstract void Start();

        public abstract void Close();

        public ISession GetConnectedSession(ISessionIdMetaData sessionId)
        {
            if(sessionId == null)
            {
                return null;
            }

            _connectedSessionLock.EnterReadLock();

            try
            {
                return _connectedSessions.Values.FirstOrDefault(session =>
                {
                    return sessionId.Equals(session.SessionId);
                });
            }
            finally
            {
                _connectedSessionLock.ExitReadLock();
            }
        }

        public IList<ISession> GetConnectedSessionMetaData(
            Func<ISession, bool> selector)
        {
            _connectedSessionLock.EnterReadLock();

            try
            {
                return _connectedSessions.Values.Where(selector).ToList();
            }
            finally
            {
                _connectedSessionLock.ExitReadLock();
            }
        }

        protected int IncrementAcceptedCount()
        {
            return Interlocked.Increment(ref _acceptedCount);
        }

        protected int DecrementAcceptedCount()
        {
            return Interlocked.Decrement(ref _acceptedCount);
        }

        protected virtual void AddConnectedSession(ISession session)
        {
            _connectedSessionLock.EnterUpgradeableReadLock();

            try
            {
                ISession oldSession;

                if (_connectedSessions.TryGetValue(session.RemoteEndPoint, out oldSession))
                {
                    if(oldSession != session)
                    {
                        _connectedSessionLock.EnterWriteLock();
                        try
                        {
                            _connectedSessions[session.RemoteEndPoint] = session;
                        }
                        finally
                        {
                            _connectedSessionLock.ExitWriteLock();
                        }
                    }
                }
                else
                {
                    _connectedSessionLock.EnterWriteLock();
                    try
                    {
                        _connectedSessions.Add(session.RemoteEndPoint, session);
                    }
                    finally
                    {
                        _connectedSessionLock.ExitWriteLock();
                    }
                }
            }
            finally
            {
                _connectedSessionLock.ExitUpgradeableReadLock();
            }
        }

        protected virtual bool RemoveConnectedSession(ISession session)
        {
            _connectedSessionLock.EnterWriteLock();

            try
            {
                return _connectedSessions.Remove(session.RemoteEndPoint);
            }
            finally
            {
                _connectedSessionLock.ExitWriteLock();
            }
        }

        protected virtual void AcceptedSession(SessionAcceptedEventArgs sessionAcceptedEventArgs)
        {
            if (SessionAccepted != null)
            {
                try
                {
                    SessionAccepted(this, sessionAcceptedEventArgs);
                }
                catch (Exception ex)
                {
                    CaughtException(ex);
                }
            }
        }

        protected virtual void CaughtException(Exception cause)
        {
            if (ExceptionCaught != null)
            {
                try
                {
                    ExceptionCaught(this, new ExceptionEventArgs(cause));
                }
                catch (Exception exception)
                {
                    _log.Error("CaughtException failed.", exception);
                }
            }
        }

        protected virtual void OnSessionCaughtException(object sender, ExceptionEventArgs e)
        {
            if (e.Exception is SocketException)
            {
                try
                {
                    ((ISession)sender).Close();
                }
                catch (Exception ex)
                {
                    _log.Error("Close session failed.", ex);
                }
            }
        }

        protected virtual void OnSessionClosed(object sender, SessionEventArgs e)
        {
            try
            {
                SessionBase session = e.Session as SessionBase;
                session.Closed -= _sessionClosedEventHandler;
                session.ExceptionCaught -= _sessionExceptionCaughtEventHandler;

                if (RemoveConnectedSession(e.Session))
                {
                    DecrementAcceptedCount();
                }

                session.Dispose();
            }
            catch(Exception ex)
            {
                CaughtException(ex);
            }
        }

        protected override void ReleaseUnManagedResources()
        {
            Close();
        }

        protected override void ReleaseManagedResources()
        {
            _connectedSessions.Clear();
            _connectedSessionLock.Dispose();
        }

        #endregion
    }
}
