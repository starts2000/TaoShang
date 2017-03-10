namespace Starts2000.Net.Session.Packet
{
    public interface IPacketDecoder
    {
        object Decode(ISession session, IPacket packet);
    }
}
