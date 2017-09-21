using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Rpc.HttpProtocol.Runtime
{
    public class RemoteInvokeClient //: IRemoteInvokeClient
    {
        private IRpcHttpClient _rpcHttpClient;
        public RemoteInvokeClient(IRpcHttpClient rpcHttpClient)
        {
            _rpcHttpClient = rpcHttpClient;
        }

        public (TResult result, string exceptionMessage) Invoke<TResult>(string invokeId, int? timeout = null) where TResult : class
        {
            return Invoke<object, TResult>(invokeId, null, timeout);
        }

        public (TResult result, string exceptionMessage) Invoke<TData, TResult>(string invokeId, TData data = default(TData), int? timeout = null) where TResult : class
        {
            TResult result;
            string exceptionMessage = null;
            try
            {
                result = _rpcHttpClient.Invoke<TData, TResult>(invokeId, data);
            }
            catch(Exception ex)
            {
                result = default(TResult);
                exceptionMessage = Exceptions.ExceptionOptimize.GetExceptionMessage(ex);
            }

            return (result, exceptionMessage);

        }

        public Task<(TResult result, string exceptionMessage)> InvokeAsync<TResult>(string invokeId, int? timeout = null) where TResult : class
        {
            return InvokeAsync(serviceId, invokeId, null, urlParameters, httpMethod, timeout);
        }

        public Task<(TResult result, string exceptionMessage)> InvokeAsync<TData, TResult>(string invokeId, TData data, int? timeout = null) where TResult : class
        {
        }

    }
}
