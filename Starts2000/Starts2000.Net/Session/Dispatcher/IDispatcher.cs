using System;

namespace Starts2000.Net.Session.Dispatcher
{
    public interface IDispatcher
    {
        void Dispatch(Action sessionAction);
    }
}
