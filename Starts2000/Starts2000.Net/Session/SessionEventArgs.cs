using System;

namespace Starts2000.Net.Session
{
    public class SessionEventArgs : EventArgs
    {
        readonly object _obj;
        readonly ISession _session;

        public object Obj
        {
            get { return _obj; }
        }

        public ISession Session
        {
            get { return _session; }
        }

        public SessionEventArgs(ISession session, object obj)
        {
            _obj = obj;
            _session = session;
        }
    }
}
