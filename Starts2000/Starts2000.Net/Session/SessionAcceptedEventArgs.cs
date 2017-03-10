using System;

namespace Starts2000.Net.Session
{
    public class SessionAcceptedEventArgs : EventArgs
    {
        readonly ISessionAcceptor _acceptor;
        readonly ISession _session;

        public ISessionAcceptor Acceptor
        {
            get { return _acceptor; }
        }

        public ISession Session
        {
            get { return _session; }
        }

        public SessionAcceptedEventArgs(ISessionAcceptor acceptor, ISession session)
        {
            _acceptor = acceptor;
            _session = session;
        }
    }
}
