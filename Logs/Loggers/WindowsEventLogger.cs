using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Logs
{
    public class WindowsEventLogger : ILogger
    {
        private const string EventLog = "Examen";
        private const string EventLogSource = "Examen";

        public Task WarningAsync(string message, int category, string parameters, object state = null)
        {
            var logMessage = message;
            using (var log = new EventLog(EventLog, ".", EventLogSource))
            {
                log.WriteEntry(logMessage, EventLogEntryType.Warning, 0, Convert.ToInt16(category));
            }

            return Task.CompletedTask;
        }

        public Task ErrorAsync(Exception ex, int category, string parameters, object state = null)
        {
            var logMessage = ex.Traverse();
            using (var log = new EventLog(EventLog, ".", EventLogSource))
            {
                log.WriteEntry(logMessage, EventLogEntryType.Error, 0, Convert.ToInt16(category));
            }

            return Task.CompletedTask;
        }

        public Task ErrorAsync(string message, int category, object state = null)
        {
            var logMessage = message;
            using (var log = new EventLog(EventLog, ".", EventLogSource))
            {
                log.WriteEntry(logMessage, EventLogEntryType.Error, 0, Convert.ToInt16(category));
            }

            return Task.CompletedTask;
        }

        public Task InfoAsync(string message, int category, object state = null)
        {
            var logMessage = message;
            using (var log = new EventLog(EventLog, ".", EventLogSource))
            {
                log.WriteEntry(logMessage, EventLogEntryType.Information, 0, Convert.ToInt16(category));
            }

            return Task.CompletedTask;
        }
    }
}