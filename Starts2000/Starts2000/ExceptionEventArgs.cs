using System;

namespace Starts2000
{
    public class ExceptionEventArgs : EventArgs
    {
        readonly Exception _exception;

        public Exception Exception
        {
            get { return _exception; }
        }

        public ExceptionEventArgs(Exception exception)
        {
            _exception = exception;
        }
    }
}
