using System;
using Starts2000.Net.Session.Packet;

namespace Starts2000.Net.Session.Filter
{
    public interface ISessionFilter
    {
        void ExceptionCaught(ISessionFilterChain filterChain, Exception cause);
        void ObjectReceived(ISessionFilterChain filterChain, object obj);
        void ObjectSent(ISessionFilterChain filterChain, object obj);
        void PacketReceived(ISessionFilterChain filterChain, IPacket packet);
        void PacketSend(ISessionFilterChain filterChain, IPacket packet);
        void PacketSent(ISessionFilterChain filterChain, IPacket packet);
        void SessionStateChanged(ISessionFilterChain filterChain);
        void SessionTimeout(ISessionFilterChain filterChain);
    }
}
