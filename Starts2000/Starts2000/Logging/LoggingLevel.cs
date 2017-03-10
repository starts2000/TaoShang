namespace Starts2000.Logging
{
    internal enum LoggingLevel : byte
    {
        Info = 0,
        Debug = 1,
        Warn = 2,
        Error = 3,
        Fatal = 4,
        None = 0xff
    }
}
