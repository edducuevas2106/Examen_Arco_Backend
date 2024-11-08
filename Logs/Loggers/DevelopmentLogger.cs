using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Logs
{
    public class DevelopmentLogger : ILogger
    {
        public Task WarningAsync(string message, int category, string parameters, object state = null)
        {
            if (state != null) message += $" =>> {state.ToJson()}";

            Trace.TraceWarning($"[{category}] {message}");
            return Task.CompletedTask;
        }

        public Task ErrorAsync(Exception ex, int category, string parameters, object state = null)
        {
            var message = ex.Traverse();

            if (state != null) message += $" =>> {state.ToJson()}";

            Trace.TraceError($"[{category}] {message}");
            return Task.CompletedTask;
        }

        public Task ErrorAsync(string message, int category, object state = null)
        {
            if (state != null) message += $" =>> {state.ToJson()}";
            ;

            Trace.TraceError($"[{category} {message}]");
            return Task.CompletedTask;
        }

        public Task InfoAsync(string message, int category, object state = null)
        {
            if (state != null) message += $" =>> {state.ToJson()}";

            Trace.TraceInformation($"[{category}] {message}");
            return Task.CompletedTask;
        }
    }
}