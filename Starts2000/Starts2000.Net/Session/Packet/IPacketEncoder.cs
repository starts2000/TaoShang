namespace Starts2000.Net.Session.Packet
{
    public interface IPacketEncoder
    {
        IPacket Encode(ISession session, object obj);
    }
}
