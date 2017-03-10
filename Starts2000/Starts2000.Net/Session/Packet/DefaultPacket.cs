using System.Net;
using Starts2000.Net.Buffer;

namespace Starts2000.Net.Session.Packet
{
    public class DefaultPacket : IPacket
    {
        IBuffer _buffer;
        IPEndPoint _endPoint;

        public IBuffer Buffer
        {
            get { return _buffer; }
            set { _buffer = value; }
        }

        public IPEndPoint EndPoint
        {
            get { return _endPoint; }
            set { _endPoint = value; }
        }

        public DefaultPacket()
        {
        }

        public DefaultPacket(IBuffer buffer)
        {
            _buffer = buffer;
        }

        public DefaultPacket(byte[] buffer)
            : this(BufferFactory.Wrap(buffer))
        {
        }

        public DefaultPacket(IBuffer buffer, IPEndPoint endPoint)
        {
            _buffer = buffer;
            _endPoint = endPoint;
        }

        public override string ToString()
        {
            return string.Format("Packet [content]:{0},  [address]:{1}.", 
                _buffer.ToString(), _endPoint.ToString());
        }
    }
}
