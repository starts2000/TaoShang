using System.Net;
using Starts2000.Net.Buffer;

namespace Starts2000.Net.Session.Packet
{
    public interface IPacket
    {
        IBuffer Buffer { get; set; }
        IPEndPoint EndPoint { get; }
    }
}
