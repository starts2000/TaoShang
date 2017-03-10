using System;

namespace Starts2000.Net.Session
{
    public interface IExceptionEvents
    {
        event EventHandler<ExceptionEventArgs> ExceptionCaught;
    }
}
