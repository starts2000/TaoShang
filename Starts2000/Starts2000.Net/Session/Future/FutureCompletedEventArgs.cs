using System;
namespace Starts2000.Net.Session.Future
{
    public class FutureCompletedEventArgs : EventArgs
    {
        readonly IFuture _future;

        public IFuture Future
        {
            get { return _future; }
        }

        public FutureCompletedEventArgs(IFuture future)
        {
            _future = future;
        }
    }
}
