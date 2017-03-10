using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starts2000.Logging
{
    internal class Logger : ILogger
    {
        #region Fields

        readonly LoggingLevel _level;
        readonly Type _type;

        const string LogFormat = "[{0}]-[{1}]: In {2} class, Message: {3}";

        #endregion

        #region Properties

        public bool IsDebugEnabled
        {
            get { return _level <= LoggingLevel.Debug; }
        }

        public bool IsErrorEnabled
        {
            get { return (_level <= LoggingLevel.Error); }
        }

        public bool IsFatalEnabled
        {
            get { return (_level <= LoggingLevel.Fatal); }
        }

        public bool IsInfoEnabled
        {
            get { return (_level <= LoggingLevel.Info); }
        }

        public bool IsWarnEnabled
        {
            get { return (_level <= LoggingLevel.Warn); }
        }

        #endregion

        #region Methods

        public Logger(Type type)
        {
            _type = type;
            //_level = (LoggingLevel)Enum.Parse(
            //    typeof(LoggingLevel), Configurations.LoggingLevel, true);
            _level = LoggingLevel.Error;
        }

        public void Debug(string message)
        {
            Debug(message, null);
        }

        public void Debug(string message, Exception exception)
        {
            try
            {
                if (IsDebugEnabled)
                {
                    WriteLog(message, exception, LoggingLevel.Debug);
                }
            }
            catch
            {
            }
        }

        public void Error(string message)
        {
            Error(message, null);
        }

        public void Error(string message, Exception exception)
        {
            try
            {
                if (IsErrorEnabled)
                {
                    WriteLog(message, exception, LoggingLevel.Error);
                }
            }
            catch
            {
            }
        }

        public void Fatal(string message)
        {
            Fatal(message, null);
        }

        public void Fatal(string message, Exception exception)
        {
            try
            {
                if (IsFatalEnabled)
                {
                    WriteLog(message, exception, LoggingLevel.Fatal);
                }
            }
            catch
            {
            }
        }

        public void Info(string message)
        {
            Info(message, null);
        }

        public void Info(string message, Exception exception)
        {
            try
            {
                if (IsDebugEnabled)
                {
                    WriteLog(message, exception, LoggingLevel.Info);
                }
            }
            catch
            {
            }
        }

        public void Warn(string message)
        {
            Warn(message, null);
        }

        public void Warn(string message, Exception exception)
        {
            try
            {
                if (IsWarnEnabled)
                {
                    WriteLog(message, exception, LoggingLevel.Warn);
                }
            }
            catch
            {
            }
        }

        string BuildLogMessage(string message, Exception exception, LoggingLevel level)
        {
            StringBuilder builder = new StringBuilder(0x400);
            builder.AppendFormat("[{0}]-[{1}]: In {2} class, Message: {3}",
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), level, _type.FullName, message);

            if (exception != null)
            {
                builder.AppendFormat("\r\nException:{0}", exception.ToString());
            }

            return builder.ToString();
        }

        void WriteLog(string message, Exception exception, LoggingLevel level)
        {
            LogWriter.WriteLog(BuildLogMessage(message, exception, level));
        }

        #endregion
    }
}
