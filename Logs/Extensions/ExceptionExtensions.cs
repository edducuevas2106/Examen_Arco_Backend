using System;
using System.Text;

namespace Logs
{
    public static class ExceptionExtensions
    {
        public static string Traverse(this Exception target)
        {
            return target is AggregateException exception
                ? TraverseAggreggateException(exception)
                : TraverseException(target);
        }

        private static string TraverseException(Exception ex)
        {
            var message = new StringBuilder(ex.Message);

            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                message.Append(Environment.NewLine + ex.Message);
            }

            return message.ToString();
        }

        private static string TraverseAggreggateException(AggregateException aex)
        {
            var message = new StringBuilder(aex.Message);

            foreach (var ex in aex.Flatten().InnerExceptions)
            {
                message.Append(Environment.NewLine + ex.Message);
                for (var e = ex.InnerException; e != null; e = e.InnerException)
                    message.Append(Environment.NewLine + e.Message);
            }

            return message.ToString();
        }
    }
}