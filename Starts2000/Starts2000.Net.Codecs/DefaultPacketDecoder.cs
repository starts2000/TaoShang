using System;
using Starts2000.Net.Buffer;
using Starts2000.Net.Codecs.Message;
using Starts2000.Net.Session;
using Starts2000.Net.Session.Packet;

namespace Starts2000.Net.Codecs
{
    public class DefaultPacketDecoder : IPacketDecoder
    {
        Func<IBuffer, int, int, ushort, object> _messageBodyDecoder;

        public DefaultPacketDecoder(Func<IBuffer, int, int, ushort, object> messageBodyDecoder)
        {
            _messageBodyDecoder = messageBodyDecoder;
        }

        public object Decode(ISession session, IPacket packet)
        {
            return DefaultMessage.FromBuffer(packet.Buffer, _messageBodyDecoder);
        }
    }
}
