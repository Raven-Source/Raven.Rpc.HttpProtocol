using Raven.Rpc.HttpProtocol.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Rpc.HttpProtocol.Runtime
{
    public class RemoteInvokeClient : IRemoteInvokeClient
    {
        private IRpcHttpClient _rpcHttpClient;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rpcHttpClient"></param>
        public RemoteInvokeClient(IRpcHttpClient rpcHttpClient)
        {
            _rpcHttpClient = rpcHttpClient;
        }

        public InvokeResultMessage<TResult> Invoke<TResult>(string serviceId, string invokeId, HttpMethod httpMethod = null, int? timeout = null) where TResult : class
        {
            TResult result;
            string exceptionMessage = null;
            try
            {
                result = _rpcHttpClient.Invoke<TResult>(invokeId);
            }
            catch (Exception ex)
            {
                result = default(TResult);
                exceptionMessage = Exceptions.ExceptionOptimize.GetExceptionMessage(ex);
            }

            return new InvokeResultMessage<TResult>() { Result = result, Exception = exceptionMessage };
        }

        public InvokeResultMessage<TResult> Invoke<TData, TResult>(string serviceId, string invokeId, TData contentData = default(TData), HttpMethod httpMethod = null, int? timeout = null) where TResult : class
        {
            TResult result;
            string exceptionMessage = null;
            try
            {
                result = _rpcHttpClient.Invoke<TData, TResult>(invokeId, contentData);
            }
            catch (Exception ex)
            {
                result = default(TResult);
                exceptionMessage = Exceptions.ExceptionOptimize.GetExceptionMessage(ex);
            }

            return new InvokeResultMessage<TResult>() { Result = result, Exception = exceptionMessage };
        }

        public async Task<InvokeResultMessage<TResult>> InvokeAsync<TResult>(string serviceId, string invokeId, HttpMethod httpMethod = null, int? timeout = null) where TResult : class
        {
            TResult result;
            string exceptionMessage = null;
            try
            {
                result = await _rpcHttpClient.InvokeAsync<TResult>(invokeId).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                result = default(TResult);
                exceptionMessage = Exceptions.ExceptionOptimize.GetExceptionMessage(ex);
            }

            return new InvokeResultMessage<TResult>() { Result = result, Exception = exceptionMessage };
        }

        public async Task<InvokeResultMessage<TResult>> InvokeAsync<TData, TResult>(string serviceId, string invokeId, TData contentData = default(TData), HttpMethod httpMethod = null, int? timeout = null) where TResult : class
        {
            TResult result;
            string exceptionMessage = null;
            try
            {
                result = await _rpcHttpClient.InvokeAsync<TData, TResult>(invokeId, contentData).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                result = default(TResult);
                exceptionMessage = Exceptions.ExceptionOptimize.GetExceptionMessage(ex);
            }

            return new InvokeResultMessage<TResult>() { Result = result, Exception = exceptionMessage };
        }
    }
}
