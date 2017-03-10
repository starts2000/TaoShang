using System;

namespace Starts2000.Logging
{
    public class LogFactory
    {
        public static ILogger CreateLogger(Type type)
        {
            return new Logger(type);
        }
    }
}
