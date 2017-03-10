using System;
using Starts2000.Net.Session.Packet;

namespace Starts2000.Net.Session.Filter
{
    public class SessionFilterAdapter : ISessionFilter
    {
        public virtual void ExceptionCaught(ISessionFilterChain filterChain, Exception exception)
        {
            filterChain.ExceptionCaught(exception);
        }

        public virtual void ObjectReceived(ISessionFilterChain filterChain, object obj)
        {
            filterChain.ObjectReceived(obj);
        }

        public virtual void ObjectSent(ISessionFilterChain filterChain, object obj)
        {
            filterChain.ObjectSent(obj);
        }

        public virtual void PacketReceived(ISessionFilterChain filterChain, IPacket packet)
        {
            filterChain.PacketReceived(packet);
        }

        public virtual void PacketSend(ISessionFilterChain filterChain, IPacket packet)
        {
            filterChain.PacketSend(packet);
        }

        public virtual void PacketSent(ISessionFilterChain filterChain, IPacket packet)
        {
            filterChain.PacketSent(packet);
        }

        public virtual void SessionStateChanged(ISessionFilterChain filterChain)
        {
            filterChain.SessionStateChanged();
        }

        public virtual void SessionTimeout(ISessionFilterChain filterChain)
        {
            filterChain.SessionTimeout();
        }
    }
}
