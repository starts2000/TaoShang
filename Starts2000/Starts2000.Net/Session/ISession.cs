using System.Collections.Generic;
using System.Net;
using Starts2000.Net.Session.Filter;
using Starts2000.Net.Session.Future;
using Starts2000.Net.Session.Packet;

namespace Starts2000.Net.Session
{
    public interface ISession : ISessionEvents, IExceptionEvents
    {
        ISessionIdMetaData SessionId { get; set; }
        SessionType SessionType { get; }
        SessionState SessionState { get; }
        bool IsOpened { get; }
        IPEndPoint LocalEndPoint { get; set; }
        IPEndPoint RemoteEndPoint { get; }
        IPacketDecoder PacketDecoder { get; set; }
        IPacketEncoder PacketEncoder { get; set; }
        IList<ISessionFilter> SessionFilters { get; }

        IFuture Open();
        IFuture Close();
        IFuture Flush(IPacket packet);
        IFuture Send(object obj);

        ISessionFilter GetSessionFilter(int index);
        void AddSessionFilter(ISessionFilter filter);
        void InsertSessionFilter(int index, ISessionFilter filter);
        void RemoveSessionFilter(ISessionFilter filter);
        ISessionFilterChain GetSessionFilterChain(FilterChainMode filterChainMode);
    }
}
