using System;

namespace Starts2000.Net.Session
{
    public interface ISessionEvents
    {
        event EventHandler<SessionEventArgs> ObjectReceived;
        event EventHandler<SessionEventArgs> ObjectSent;
        event EventHandler<SessionEventArgs> StateChanged;
        event EventHandler<SessionEventArgs> TimedOut;
    }
}
