using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using Ninject.Extensions.Logging;
using Starts2000.Net.Buffer;
using Starts2000.Net.Codecs;
using Starts2000.Net.Codecs.Message;
using Starts2000.Net.Session;
using Starts2000.Net.Session.Future;
using Starts2000.TaoBao.Core.Utils;

namespace Starts2000.TaoBao.Core
{
    internal class Communication
    {
        IPEndPoint _remoteEP;
        AsyncTcpSession _session;
        readonly Func<object, byte[]> _messageBodyEncoder;
        readonly Func<IBuffer, int, int, ushort, object> _messageBodyDecoder;
        readonly IDictionary<ushort, MessageFilterInfo> _filterInfos;
        readonly object _rootSync = new object();

        internal Communication(string address, int port)
        {
            _remoteEP = new IPEndPoint(IPAddress.Parse(address), port);
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

        internal IFuture Start()
        {
            lock (_rootSync)
            {
                if (_session != null && (_session.IsOpened ||
                    _session.SessionState == SessionState.Opening))
                {
                    return null;
                }

                if(_session != null)
                {
                    _session.Close();
                    _session = null;
                }

                if (_session == null)
                {
                    _session = new AsyncTcpSession(_remoteEP, true, 5000, 10000, true);
                    _session.PacketEncoder = new DefaultPacketEncoder(_messageBodyEncoder);
                    _session.PacketDecoder = new DefaultPacketDecoder(_messageBodyDecoder);
                    _session.ObjectReceived += SessionObjectReceived;
                    _session.ExceptionCaught += SessionExceptionCaught;
                    _session.StateChanged += SessionStateChanged;
                    _session.Closed += SessionClosed;
                }

                return _session.Open();
            }
        }

        internal void Close()
        {
            lock (_rootSync)
            {
                if (_session != null && _session.SessionState != SessionState.Closed)
                {
                    _session.Close();
                    _session = null;
                }
            }
        }

        internal void AddFilter(ushort msgType, MessageFilterInfo info)
        {
            _filterInfos.Add(msgType, info);
        }

        internal IFuture Send(object data, ushort type, 
            ushort subType = 0, bool zip = false, bool encrypted = false)
        {
            if(_session == null || !_session.IsOpened)
            {
                Start();

                lock (_rootSync)
                {
                    int count = 0;
                    while (!_session.IsOpened && count < 10)
                    {
                        Thread.Sleep(1000);
                        count++;
                    }
                }
            }

            if (_session.IsOpened)
            {
                return _session.Send(new DefaultMessage(data, type, subType, zip, encrypted));
            }

            return null;
        }

        void SessionExceptionCaught(object sender, ExceptionEventArgs e)
        {
            try
            {
                Global.Resolve<ILoggerFactory>()
                    .GetCurrentClassLogger()
                    .ErrorException("Session Exception.", e.Exception);
            }
            catch
            {
            }
        }

        void SessionClosed(object sender, SessionEventArgs e)
        {
            _session.ObjectReceived -= SessionObjectReceived;
            _session.ExceptionCaught -= SessionExceptionCaught;
            _session.Closed -= SessionClosed;
            _session = null;

            Global.Resolve<ILoggerFactory>()
                    .GetCurrentClassLogger()
                    .Info("Session Closed: {0}", e.Session);
        }

        void SessionStateChanged(object sender, SessionEventArgs e)
        {
            Global.Resolve<ILoggerFactory>()
                    .GetCurrentClassLogger()
                    .Info("Session State Changed: {0}", e.Session.SessionState);
        }

        void SessionObjectReceived(object sender, SessionEventArgs e)
        {
            var msg = e.Obj as IMessage;
            if (msg != null)
            {
                MessageFilterInfo info;
                if (_filterInfos.TryGetValue(msg.Header.Type, out info))
                {
                    info.Filter.MessageHandler(msg, e);
                }
            }
        }
    }
}