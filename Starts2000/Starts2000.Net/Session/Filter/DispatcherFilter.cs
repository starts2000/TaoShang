using System;
using Starts2000.Net.Session.Dispatcher;
using Starts2000.Net.Session.Packet;

namespace Starts2000.Net.Session.Filter
{
    public class DispatcherFilter : ISessionFilter
    {
        readonly IDispatcher _dispatcher;

        public IDispatcher Dispatcher
        {
            get { return _dispatcher; }
        }

        public DispatcherFilter(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        public void ExceptionCaught(ISessionFilterChain filterChain, Exception cause)
        {
            //_dispatcher.Dispatch(filterChain.Session, () => filterChain.ExceptionCaught(cause));
        }

        public void ObjectReceived(ISessionFilterChain filterChain, object obj)
        {
            _dispatcher.Dispatch(() => filterChain.ObjectReceived(obj));
        }

        public void ObjectSent(ISessionFilterChain filterChain, object obj)
        {        
            _dispatcher.Dispatch(() => filterChain.ObjectSent(obj));
        }

        public void PacketReceived(ISessionFilterChain filterChain, IPacket packet)
        {
            _dispatcher.Dispatch(() => filterChain.PacketReceived(packet));
        }

        public void PacketSend(ISessionFilterChain filterChain, IPacket packet)
        {
            _dispatcher.Dispatch(() => filterChain.PacketSend(packet));
        }

        public void PacketSent(ISessionFilterChain filterChain, IPacket packet)
        {
            _dispatcher.Dispatch(() => filterChain.PacketSent(packet));
        }

        public void SessionStateChanged(ISessionFilterChain filterChain)
        {
            _dispatcher.Dispatch(() => filterChain.SessionStateChanged());
        }

        public void SessionTimeout(ISessionFilterChain filterChain)
        {
            _dispatcher.Dispatch(() => filterChain.SessionTimeout());
        }
    }
}
