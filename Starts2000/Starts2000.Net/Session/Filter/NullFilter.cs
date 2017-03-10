using System;
using Starts2000.Net.Session.Packet;

namespace Starts2000.Net.Session.Filter
{
    public class NullFilter : ISessionFilter
    {
        public virtual void ExceptionCaught(ISessionFilterChain filterChain, Exception exception)
        {
        }

        public virtual void ObjectReceived(ISessionFilterChain filterChain, object obj)
        {
        }

        public virtual void ObjectSent(ISessionFilterChain filterChain, object obj)
        {
        }

        public virtual void PacketReceived(ISessionFilterChain filterChain, IPacket packet)
        {
        }

        public virtual void PacketSend(ISessionFilterChain filterChain, IPacket packet)
        {
        }

        public virtual void PacketSent(ISessionFilterChain filterChain, IPacket packet)
        {
        }

        public virtual void SessionClosed(ISessionFilterChain filterChain)
        {
        }

        public virtual void SessionStateChanged(ISessionFilterChain filterChain)
        {
        }

        public virtual void SessionTimeout(ISessionFilterChain filterChain)
        {
        }
    }
}
