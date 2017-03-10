using System;
using System.Net;
using System.Reflection;
using Starts2000.Logging;
using Starts2000.Net.Buffer;
using Starts2000.Net.Session.Packet;

namespace Starts2000.Net.Session.Filter
{
    public class PacketDecoderFilter : SessionFilterAdapter
    {
        static readonly ILogger _log = LogFactory.CreateLogger(MethodBase.GetCurrentMethod().ReflectedType);
        protected readonly ISession _session;

        protected PacketDecoderFilter(ISession session)
        {
            _session = session;
        }

        public static PacketDecoderFilter NewInstance(ISession session)
        {
            if (session.SessionType == SessionType.Udp)
            {
                return new DiscardPacketDecoderFilter(session);
            }

            if (session.SessionType != SessionType.Tcp)
            {
                throw new ArgumentException();
            }

            return new CopyPacketDecoderFilter(session);
        }

        protected void Recognize(IBuffer content, IPEndPoint endpoint)
        {
            if (_log.IsInfoEnabled)
            {
                _log.Info("Enter Recognize.");
            }

            while (content.HasRemaining)
            {
                try
                {
                    IBuffer buffer = content.AsReadOnlyBuffer().Slice();
                    int position = buffer.Position;

                    if (_session == null || _session.PacketDecoder == null)
                    {
                        break;
                    }

                    object obj = _session.PacketDecoder.Decode(
                        _session, new DefaultPacket(buffer, endpoint));

                    if (obj == null)
                    {
                        if (_log.IsDebugEnabled)
                        {
                            _log.Debug("Decode failed.");
                        }
                        break;
                    }

                    if (position == buffer.Position)
                    {
                        throw new Exception("PacketDecoder should change the packet position.");
                    }

                    content.Skip(buffer.Position);

                    if (_log.IsInfoEnabled)
                    {
                        _log.Info(obj.ToString());
                    }

                    _session.GetSessionFilterChain(FilterChainMode.Receive).ObjectReceived(obj);
                    continue;
                }
                catch (Exception exception)
                {
                    if (_log.IsWarnEnabled)
                    {
                        _log.Warn("Recognize failed.", exception);
                    }
                    break;
                }
            }

            if (_log.IsInfoEnabled)
            {
                _log.Info("Exit Recognize.");
            }
        }

        private class CopyPacketDecoderFilter : PacketDecoderFilter
        {
            IBuffer _content;
            IPEndPoint _endPoint;

            public CopyPacketDecoderFilter(ISession session)
                : base(session)
            {
            }

            public override void PacketReceived(ISessionFilterChain filterChain, IPacket packet)
            {
                if (packet == null || filterChain.Session != base._session)
                {
                    base.PacketReceived(filterChain, packet);
                }
                else
                {
                    lock (this)
                    {
                        if (_content == null)
                        {
                            _content = packet.Buffer;
                            _endPoint = packet.EndPoint;
                        }
                        else
                        {
                            IBuffer content = packet.Buffer;

                            if (_content.Remaining < content.Remaining)
                            {
                                IBuffer buffer = BufferFactory.GetBuffer(
                                    _content.Position + content.Remaining);

                                buffer.Put(_content.Flip());
                                _content.Release();
                                _content = buffer;
                            }

                            _content.Put(content);
                            _content.Flip();
                        }

                        if (_content != null)
                        {
                            try
                            {
                                base.Recognize(_content, _endPoint);
                            }
                            finally
                            {
                                if (_content.HasRemaining)
                                {
                                    _content.Compact();
                                }
                                else
                                {
                                    _content.Release();
                                    _content = null;
                                    _endPoint = null;
                                }
                            }
                        }
                    }
                }
            }

            public override void SessionStateChanged(ISessionFilterChain filterChain)
            {
                if (filterChain.Session == base._session && base._session.SessionState == SessionState.Closed)
                {
                    lock (this)
                    {
                        if (_content != null)
                        {
                            _content.Release();
                            _content = null;
                        }

                        _endPoint = null;
                    }
                }

                base.SessionStateChanged(filterChain);
            }
        }

        private class DiscardPacketDecoderFilter : PacketDecoderFilter
        {
            public DiscardPacketDecoderFilter(ISession session)
                : base(session)
            {
            }

            public override void PacketReceived(ISessionFilterChain filterChain, IPacket packet)
            {
                if (packet == null || filterChain.Session != base._session)
                {
                    base.PacketReceived(filterChain, packet);
                }
                else
                {
                    IBuffer content = packet.Buffer;

                    if (content != null)
                    {
                        try
                        {
                            base.Recognize(content, packet.EndPoint);
                        }
                        finally
                        {
                            content.Release();
                        }
                    }
                }
            }
        }
    }
}