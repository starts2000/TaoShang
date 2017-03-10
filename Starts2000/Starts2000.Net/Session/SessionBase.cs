using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using Starts2000.Logging;
using Starts2000.Net.Session.Dispatcher;
using Starts2000.Net.Session.Filter;
using Starts2000.Net.Session.Future;
using Starts2000.Net.Session.Packet;

namespace Starts2000.Net.Session
{
    public abstract class SessionBase : DisposableBase, ISession
    {
        #region Fields

        SessionState _sessionState = SessionState.Initial;
        IPEndPoint _localEndPoint;
        IPEndPoint _remoteEndPoint;
        IPacketDecoder _packetDecoder;
        IPacketEncoder _packetEncoder;

        readonly SessionType _sessionType;
        readonly IList<ISessionFilter> _filters = new List<ISessionFilter>();
        readonly ISessionFilter _handlerFilter = new SessionHandlerFilter();
        readonly ISessionFilter _packetDecoderFilter;

        static readonly DispatcherFilter DISPATCH_FILTER =
            new DispatcherFilter(DispatcherFactory.GetDispatcher());
        static readonly ILogger _log = LogFactory.CreateLogger(MethodBase.GetCurrentMethod().ReflectedType);

        #endregion

        #region Events

        /// <summary>
        /// 会话打开后发生。
        /// </summary>
        public event EventHandler<SessionEventArgs> Opened;

        /// <summary>
        /// 会话关闭后发生。
        /// </summary>
        public event EventHandler<SessionEventArgs> Closed;

        /// <summary>
        /// 会话发送一个对象完成后发生。
        /// </summary>
        public event EventHandler<SessionEventArgs> ObjectSent;

        /// <summary>
        /// 会话接收到一个消息对象后发生。
        /// </summary>
        public event EventHandler<SessionEventArgs> ObjectReceived;

        /// <summary>
        /// 会话状态改变后发生。
        /// </summary>
        public event EventHandler<SessionEventArgs> StateChanged;

        /// <summary>
        /// 会话操作超时后发生。
        /// </summary>
        public event EventHandler<SessionEventArgs> TimedOut;

        /// <summary>
        /// 会话捕捉到异常后发生。
        /// </summary>
        public event EventHandler<ExceptionEventArgs> ExceptionCaught;

        #endregion

        #region Properties

        public ISessionIdMetaData SessionId { get; set; }

        public SessionType SessionType
        {
            get { return _sessionType; }
        }

        public SessionState SessionState
        {
            get { return _sessionState; }
            protected set
            {
                if (_sessionState != value)
                {
                    _sessionState = value;
                    GetSessionFilterChain(FilterChainMode.Send).SessionStateChanged();
                }
            }
        }

        public bool IsOpened
        {
            get { return _sessionState == SessionState.Opened; }
        }

        /// <summary>
        /// 获取地网络地址。
        /// </summary>
        /// <returns>本地网络地址。</returns>
        public virtual IPEndPoint LocalEndPoint
        {
            get { return _localEndPoint; }
            set { _localEndPoint = value; }
        }

        /// <summary>
        /// 获取远程服务网络地址。
        /// </summary>
        /// <returns>远程服务网络地址。</returns>
        public IPEndPoint RemoteEndPoint
        {
            get { return _remoteEndPoint; }
            protected set { _remoteEndPoint = value; }
        }

        /// <summary>
        /// 获取或设置会话的数据包解码器。
        /// </summary>
        /// <returns>一个 <see cref="IPacketDecoder"/> 解码器接口对象。</returns>
        public IPacketDecoder PacketDecoder
        {
            get { return _packetDecoder; }
            set { _packetDecoder = value; }
        }

        /// <summary>
        /// 获取或设置会话的数据包编码器。
        /// </summary>
        /// <returns>一个 <see cref="IPacketEncoder"/> 编码器接口对象。</returns>
        public IPacketEncoder PacketEncoder
        {
            get { return _packetEncoder; }
            set { _packetEncoder = value; }
        }

        /// <summary>
        /// 获取会话过滤器列表。
        /// </summary>
        /// <returns>一个 <see cref="IList&ltISessionFilter&gt"/> 会话过滤器列表。</returns>
        public IList<ISessionFilter> SessionFilters
        {
            get { return _filters; }
        }

        #endregion

        #region Constructors

        protected SessionBase(SessionType sessionType)
        {
            _sessionType = sessionType;
            _packetDecoderFilter = PacketDecoderFilter.NewInstance(this);
        }

        protected SessionBase(SessionType sessionType, IPEndPoint remoteEndPoint)
            : this(sessionType)
        {
            _remoteEndPoint = remoteEndPoint;
        }

        #endregion

        #region Methods

        public abstract IFuture Open();

        public abstract IFuture Close();

        public IFuture Send(object obj)
        {
            IPacket packet;

            try
            {
                packet = PacketEncoder.Encode(this, obj);
            }
            catch (Exception ex)
            {
                SessionCaughtException(ex);

                AsyncFuture future = new AsyncFuture(this);
                future.AssociatedObject = obj;

                return future;
            }

            return Send(obj, packet);
        }

        public IFuture Flush(IPacket packet)
        {
            return Send(null, packet);
        }

        public void AddSessionFilter(ISessionFilter filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("filter");
            }

            _filters.Add(filter);
        }

        public void InsertSessionFilter(int index, ISessionFilter filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("filter");
            }

            _filters.Insert(index, filter);
        }

        public ISessionFilter GetSessionFilter(int index)
        {
            return _filters[index];
        }

        public void RemoveSessionFilter(ISessionFilter filter)
        {
            _filters.Remove(filter);
        }

        public ISessionFilterChain GetSessionFilterChain(FilterChainMode filterChainMode)
        {
            return new DefaultSessionFilterChain(this, filterChainMode);
        }

        protected ISessionFilterChain GetSessionFilterChain(
            ISessionFilter operateFilter, FilterChainMode filterChainMode)
        {
            return new DefaultSessionFilterChain(this, filterChainMode, operateFilter);
        }

        protected abstract IFuture Send(object obj, IPacket packet);

        protected void SessionOpened()
        {
            FireEvent(Opened, new SessionEventArgs(this, null));
        }

        protected void SessionClosed()
        {
            FireEvent(Closed, new SessionEventArgs(this, null));
        }

        protected void SessionReceivedObject(object obj)
        {
            FireEvent(ObjectReceived, new SessionEventArgs(this, obj));
        }

        protected void SessionSentObject(object obj)
        {
            FireEvent(ObjectSent, new SessionEventArgs(this, obj));
        }

        protected void SessionStateChanged()
        {
            FireEvent(StateChanged, new SessionEventArgs(this, null));
        }

        protected void SessionTimeout()
        {
            FireEvent(TimedOut, new SessionEventArgs(this, null));
        }

        protected void SessionCaughtException(Exception cause)
        {
            try
            {
                EventHandler<ExceptionEventArgs> exceptionCaught = ExceptionCaught;

                if (/*!Configurations.DisableInnerException && */exceptionCaught != null)
                {
                    exceptionCaught(this, new ExceptionEventArgs(cause));
                }
            }
            catch (Exception ex)
            {
                _log.Error("SessionCaughtException failed.", ex);
            }
        }

        protected override void ReleaseUnManagedResources()
        {
            try
            {
                Close();//.Complete();
            }
            catch (Exception ex)
            {
                _log.Error("ReleaseUnManagedResources failed.", ex);
            }
        }

        protected override void ReleaseManagedResources()
        {
            if (_filters != null)
            {
                _filters.Clear();
            }

            base.ReleaseManagedResources();
        }

        #endregion

        #region Private Methods

        void FireEvent(EventHandler<SessionEventArgs> handler, SessionEventArgs args)
        {
            if (handler != null)
            {
                try
                {
                    handler(this, args);
                }
                catch (Exception ex)
                {
                    SessionCaughtException(ex);
                    _log.Error(handler.ToString() + " failed.", ex);
                }
            }
        }

        #endregion

        #region DefaultSessionFilterChain Class

        public class DefaultSessionFilterChain : SessionFilterChainBase
        {
            #region Fields

            int _cursor;
            ISessionFilter _decodeFilter;
            ISessionFilter _dispatchFilter;
            ISessionFilter _handlerFilter;
            ISessionFilter _operateFilter;

            readonly FilterChainMode _filterChainMode;
            readonly List<ISessionFilter> _appFilters;
            readonly SessionBase _parentSession;

            const int INIT_CURSOR = -1;

            #endregion

            protected override ISessionFilter NextFilter
            {
                get
                {
                    ISessionFilter handlerFilter;

                    if (_dispatchFilter != null)
                    {
                        handlerFilter = _dispatchFilter;
                        _dispatchFilter = null;
                        return handlerFilter;
                    }

                    if (HasNextFilter())
                    {
                        return _appFilters[_cursor];
                    }

                    if (_operateFilter != null)
                    {
                        handlerFilter = _operateFilter;
                        _operateFilter = null;
                        return handlerFilter;
                    }

                    if (_decodeFilter != null)
                    {
                        handlerFilter = _decodeFilter;
                        _decodeFilter = null;
                        return handlerFilter;
                    }

                    handlerFilter = _handlerFilter;
                    _handlerFilter = null;

                    return handlerFilter;
                }
            }

            public override ISession Session
            {
                get
                {
                    return _parentSession;
                }
            }

            public DefaultSessionFilterChain(SessionBase session, FilterChainMode filterChainMode)
                : this(session, filterChainMode, null)
            {
            }

            public DefaultSessionFilterChain(SessionBase session,
                FilterChainMode filterChainMode, ISessionFilter operateFilter)
            {
                _dispatchFilter = SessionBase.DISPATCH_FILTER;
                _parentSession = session;
                _appFilters = new List<ISessionFilter>(_parentSession._filters);
                _decodeFilter = _parentSession._packetDecoderFilter;
                _operateFilter = operateFilter;
                _filterChainMode = filterChainMode;
                _handlerFilter = session._handlerFilter;
                _cursor = _filterChainMode == FilterChainMode.Send ? _appFilters.Count : INIT_CURSOR;
            }

            bool HasNextFilter()
            {
                return (_filterChainMode == FilterChainMode.Send && --_cursor >= 0) ||
                    (_filterChainMode == FilterChainMode.Receive && ++_cursor < _appFilters.Count);
            }
        }

        #endregion

        #region SessionHandlerFilter Class

        private class SessionHandlerFilter : SessionFilterAdapter
        {
            public override void ExceptionCaught(ISessionFilterChain filterChain, Exception cause)
            {
                ((SessionBase)filterChain.Session).SessionCaughtException(cause);
                base.ExceptionCaught(filterChain, cause);
            }

            public override void ObjectReceived(ISessionFilterChain filterChain, object obj)
            {
                ((SessionBase)filterChain.Session).SessionReceivedObject(obj);
                base.ObjectReceived(filterChain, obj);
            }

            public override void ObjectSent(ISessionFilterChain filterChain, object obj)
            {
                ((SessionBase)filterChain.Session).SessionSentObject(obj);
                base.ObjectSent(filterChain, obj);
            }

            public override void SessionStateChanged(ISessionFilterChain filterChain)
            {
                ((SessionBase)filterChain.Session).SessionStateChanged();
                base.SessionStateChanged(filterChain);
            }

            public override void SessionTimeout(ISessionFilterChain filterChain)
            {
                //((SessionBase)filterChain.Session).SessionTimeout();
                base.SessionTimeout(filterChain);
            }
        }

        #endregion
    }
}