using System;
using System.Linq;
using System.Threading.Tasks;

namespace Raven.Rpc.HttpProtocol.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    internal static class ExceptionOptimize
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        internal static Exception Filter(Exception ex)
        {
            if (ex is TaskCanceledException)
            {
                return new InvokeTimeoutException();
            }
            else if (ex is AggregateException aggrExc)
            {
                if (aggrExc.InnerException is TaskCanceledException || aggrExc.InnerExceptions.Any(x => x is TaskCanceledException))
                {
                    return new InvokeTimeoutException();
                }

            }
            return ex;
        }

        internal static string GetExceptionMessage(Exception exception)
        {
            if (exception == null)
                return string.Empty;

            var message = exception.Message;
            if (exception.InnerException != null)
            {
                message += "|InnerException:" + GetExceptionMessage(exception.InnerException);
            }
            return message;
        }
    }
}
