using System;
using Starts2000.Net.Session.Packet;

namespace Starts2000.Net.Session.Filter
{
    public interface ISessionFilterChain
    {
        ISession Session { get; }

        void ExceptionCaught(Exception exception);
        void ObjectReceived(object obj);
        void ObjectSent(object obj);
        void PacketReceived(IPacket packet);
        void PacketSend(IPacket packet);
        void PacketSent(IPacket packet);
        void SessionStateChanged();
        void SessionTimeout();
    }
}
