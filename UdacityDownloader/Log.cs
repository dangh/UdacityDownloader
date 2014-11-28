using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdacityDownloader
{
    public class Log
    {
        private static Log _logger = new Log();

        private Log()
        {
        }

        #region Log event

        private void RaiseLogEvent(LogType type, string message, bool crlf)
        {
            if (OnLogReceive == null)
                return;

            if (crlf)
                message += Environment.NewLine;

            var args = new LogEventArgs(type, message);
            OnLogReceive(this, args);
        }

        public delegate void LogReceiveHandler(object sender, LogEventArgs args);

        public event LogReceiveHandler OnLogReceive;

        #endregion

        #region Static methods

        public static void AttachObserver(LogReceiveHandler handler)
        {
            _logger.OnLogReceive += handler;
        }

        public static void Verbose(string message, bool crlf = true)
        {
            _logger.RaiseLogEvent(LogType.Verbose, message, crlf);
        }

        public static void Debug(string message, bool crlf = true)
        {
            _logger.RaiseLogEvent(LogType.Debug, message, crlf);
        }

        public static void Error(string message, bool crlf = true)
        {
            _logger.RaiseLogEvent(LogType.Error, message, crlf);
        }

        public static void Warning(string message, bool crlf = true)
        {
            _logger.RaiseLogEvent(LogType.Warning, message, crlf);
        }

        public static void Info(string message, bool crlf = true)
        {
            _logger.RaiseLogEvent(LogType.Info, message, crlf);
        }

        public static void Handle(Exception ex)
        {
            Debug(ex.ToString());
        }

        #endregion
    }

    public class LogEventArgs : EventArgs
    {
        public LogType Type { get; set; }

        public string Message { get; set; }

        public LogEventArgs(LogType type, string message)
        {
            Type = type;
            Message = message;
        }
    }

    public enum LogType
    {
        Verbose,
        Debug,
        Error,
        Warning,
        Info
    }
}
