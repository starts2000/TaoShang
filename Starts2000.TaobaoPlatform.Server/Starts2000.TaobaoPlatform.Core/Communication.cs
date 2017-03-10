using System;
using System.Collections.Generic;
using Ninject.Extensions.Logging;
using Starts2000.Net.Buffer;
using Starts2000.Net.Codecs;
using Starts2000.Net.Session;
using Starts2000.TaobaoPlatform.Core.MessageFilters;
using Starts2000.TaobaoPlatform.Core.Utils;
using Starts2000.TaobaoPlatform.IBll;

namespace Starts2000.TaobaoPlatform.Core
{
    internal class Communication
    {
        AsyncSocketSessionAcceptor _acceptor;
        readonly Func<object, byte[]> _messageBodyEncoder;
        readonly Func<IBuffer, int, int, ushort, object> _messageBodyDecoder;
        readonly IDictionary<ushort, MessageFilterInfo> _filterInfos;
        int _port;

        internal SessionAcceptorBase SessionAcceptor
        {
            get { return _acceptor; }
        }

        internal Communication(int port)
        {
            _port = port;
            _filterInfos = new Dictionary<ushort, MessageFilterInfo>();
            _messageBodyEncoder = obj =>
            {
                return SerializeHelper.Serialize(obj);
            };

            _messageBodyDecoder = (buffer, index, count, messageType) =>
            {
                return SerializeHelper.Deserialize(
                    buffer.ByteArray, index, count, _filterInfos[messageType].Type);
            };
        }

        internal void Start()
        {
            if (_acceptor != null && _acceptor.Started)
            {
                return;
            }

            _acceptor = new AsyncSocketSessionAcceptor(_port);
            _acceptor.Backlog = 200;
            _acceptor.ReuseAddress = true;
            _acceptor.PacketEncoder = new DefaultPacketEncoder(_messageBodyEncoder);
            _acceptor.PacketDecoder = new DefaultPacketDecoder(_messageBodyDecoder);
            _acceptor.SessionAccepted += SessionAccepted;
            _acceptor.ExceptionCaught += AcceptorExceptionCaught;
            _acceptor.Start();
        }

        internal void Close()
        {
            if (_acceptor != null && _acceptor.Started)
            {
                _acceptor.Close();
                _acceptor = null;
            }
        }

        internal void AddFilter(ushort msgType, MessageFilterInfo info)
        {
            _filterInfos.Add(msgType, info);
        }

        void SessionAccepted(object sender, SessionAcceptedEventArgs e)
        {
            e.Session.SessionId = null;
            e.Session.ObjectReceived += SessionObjectReceived;
            e.Session.ExceptionCaught += SessionExceptionCaught;
            ((SessionBase)e.Session).Closed += SessionClosed;
        }

        void SessionClosed(object sender, SessionEventArgs e)
        {
            e.Session.ObjectReceived -= SessionObjectReceived;
            e.Session.ExceptionCaught -= SessionExceptionCaught;
            ((SessionBase)e.Session).Closed -= SessionClosed;
            var sessionId = e.Session.SessionId as UserSessionIdMetaData;
            if(sessionId != null && sessionId.IsClient)
            {
                var userBll = Global.Resolve<IUserBll>();
                userBll.UpdateClientLogout(sessionId.Id);
            }

            try
            {
                if (sessionId != null)
                {
                    Global.Resolve<ILoggerFactory>()
                            .GetCurrentClassLogger()
                            .Info("Session Closed! RemoteIP:{0}, id:{1}, Account:{2}, Client:{3}.",
                                 e.Session.RemoteEndPoint, sessionId.Id, sessionId.Account, sessionId.IsClient);
                }
                else
                {
                    Global.Resolve<ILoggerFactory>()
                            .GetCurrentClassLogger()
                            .Info("Session Closed:{0}!", e.Session.RemoteEndPoint.ToString());
                }
            }
            catch
            {
            }

            e.Session.SessionId = null;
        }

        void AcceptorExceptionCaught(object sender, ExceptionEventArgs e)
        {
            try
            {
                Global.Resolve<ILoggerFactory>()
                    .GetCurrentClassLogger()
                    .ErrorException("Acceptor Exception.", e.Exception);
            }
            catch
            {
            }
        }

        void SessionExceptionCaught(object sender, ExceptionEventArgs e)
        {
            try
            {
                var session = sender as ISession;
                Global.Resolve<ILoggerFactory>()
                    .GetCurrentClassLogger()
                    .Error(e.Exception, "Session Exception: Id: {0}, IP: {1}.", 
                        session.SessionId, session.RemoteEndPoint);
            }
            catch
            {
            }
        }

        void SessionObjectReceived(object sender, SessionEventArgs e)
        {
            var msg = e.Obj as IMessage;
            if(msg != null)
            {
                MessageFilterInfo info;
                if(_filterInfos.TryGetValue(msg.Header.Type, out info))
                {
                    info.Filter.MessageHandler(msg, e);
                }
            }
        }
    }
}