using Starts2000.Net.Session.Future;

namespace Starts2000.Net.Session
{
    internal class AsyncSocketSessionToken
    {
        public AsyncSocketSession Session { get; set; }
        public AsyncFuture Future { get; set; }
        public object State { get; set; }

        public AsyncSocketSessionToken()
        {
        }

        public AsyncSocketSessionToken(AsyncSocketSession session, AsyncFuture future, object state)
        {
            Session = session;
            Future = future;
            State = state;
        }
    }
}
