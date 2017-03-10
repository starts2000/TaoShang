using System;

namespace Starts2000.Logging
{
    public interface ILogger
    {
        bool IsDebugEnabled { get; }
        bool IsErrorEnabled { get; }
        bool IsFatalEnabled { get; }
        bool IsInfoEnabled { get; }
        bool IsWarnEnabled { get; }

        void Debug(string message);
        void Debug(string message, Exception exception);
        void Error(string message);
        void Error(string message, Exception exception);
        void Fatal(string message);
        void Fatal(string message, Exception exception);
        void Info(string message);
        void Info(string message, Exception exception);
        void Warn(string message);
        void Warn(string message, Exception exception);
    }
}
