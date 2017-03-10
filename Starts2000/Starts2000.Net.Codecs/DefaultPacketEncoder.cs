using System;
using Starts2000.Net.Codecs.Message;
using Starts2000.Net.Session;
using Starts2000.Net.Session.Packet;

namespace Starts2000.Net.Codecs
{
    public class DefaultPacketEncoder : IPacketEncoder
    {
        readonly Func<object, byte[]> _messageBodyEncoder;

        public DefaultPacketEncoder(Func<object, byte[]> messageBodyEncoder)
        {
            _messageBodyEncoder = messageBodyEncoder;
        }

        public IPacket Encode(ISession session, object obj)
        {
           var message = obj as DefaultMessage;
            if(message != null)
            {
                return new DefaultPacket(DefaultMessage.ToBuffer(message, _messageBodyEncoder));
            }

            return null;
        }
    }
}