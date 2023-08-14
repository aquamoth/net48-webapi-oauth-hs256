using Microsoft.Owin.Logging;
using System;
using System.Diagnostics;

namespace OauthWebClient
{
    public class LoggerFactory : ILoggerFactory
    {
        public ILogger Create(string name) => new DebugLogger();
    }

    public class DebugLogger : ILogger
    {
        public bool WriteCore(TraceEventType eventType, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
        {
            if (eventId == 0 && state == null) return true;

            Debug.WriteLine($"{DateTime.UtcNow:HH:mm:ss.fff} [{eventId}] {formatter(state, exception)}");
            return true;
        }
    }
}
