using System.Diagnostics;

namespace Starts2000.Logging
{
    internal class LogWriter
    {
        internal static void WriteLog(string content)
        {
            if (content != null && content.Length != 0)
            {
                Trace.WriteLine(content);
            }
        }
    }
}
