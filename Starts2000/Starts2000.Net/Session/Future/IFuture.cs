using System;

namespace Starts2000.Net.Session.Future
{
    public interface IFuture
    {
        event EventHandler<FutureCompletedEventArgs> FutureCompleted;

        bool IsCompleted { get; }
        bool IsSucceeded { get; }
        ISession Session { get; }

        bool Complete();
        bool Complete(int timeout);
    }
}
