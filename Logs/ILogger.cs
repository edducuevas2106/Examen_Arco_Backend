using System;
using System.Threading.Tasks;

namespace Logs
{
    public interface ILogger
    {
        Task WarningAsync(string message, int category, string parameters, object state = null);
        Task ErrorAsync(Exception ex, int category, string parameters, object state = null);
        Task ErrorAsync(string message, int category, object state = null);
        Task InfoAsync(string message, int category, object state = null);
    }
}