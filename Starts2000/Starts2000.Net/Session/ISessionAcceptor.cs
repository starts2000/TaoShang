using System;
using System.Net;

namespace Starts2000.Net.Session
{
    public interface ISessionAcceptor : IDisposable
    {
        event EventHandler<ExceptionEventArgs> ExceptionCaught;
        event EventHandler<SessionAcceptedEventArgs> SessionAccepted;

        int AcceptedCount { get; }
        int Backlog { get; set; }
        IPEndPoint ListenEndPoint { get; set; }
        bool ReuseAddress { get; set; }
        SessionType SessionType { get; }
        bool Started { get; }

        void Close();
        void Start();
    }
}
