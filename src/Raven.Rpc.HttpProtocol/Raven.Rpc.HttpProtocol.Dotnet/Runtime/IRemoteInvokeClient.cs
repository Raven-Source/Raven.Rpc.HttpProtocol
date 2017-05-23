using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Rpc.HttpProtocol.Runtime
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRemoteInvokeClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="serviceId"></param>
        /// <param name="relativeUrl"></param>
        /// <param name="contentData"></param>
        /// <param name="httpMethod"></param>
        /// <param name="urlParameters"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        TResult Invoke<TData, TResult>(string serviceId, string relativeUrl, TData contentData = default(TData), IDictionary<string, string> urlParameters = null, HttpMethod httpMethod = null, int? timeout = null)
            where TResult : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="serviceId"></param>
        /// <param name="relativeUrl"></param>
        /// <param name="httpMethod"></param>
        /// <param name="urlParameters"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        TResult Invoke<TResult>(string serviceId, string relativeUrl, IDictionary<string, string> urlParameters = null, HttpMethod httpMethod = null, int? timeout = null)
            where TResult : class;


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="serviceId"></param>
        /// <param name="relativeUrl"></param>
        /// <param name="contentData"></param>
        /// <param name="httpMethod"></param>
        /// <param name="urlParameters"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        Task<TResult> InvokeAsync<TData, TResult>(string serviceId, string relativeUrl, TData contentData = default(TData), IDictionary<string, string> urlParameters = null, HttpMethod httpMethod = null, int? timeout = null)
            where TResult : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="serviceId"></param>
        /// <param name="relativeUrl"></param>
        /// <param name="httpMethod"></param>
        /// <param name="urlParameters"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        Task<TResult> InvokeAsync<TResult>(string serviceId, string relativeUrl, IDictionary<string, string> urlParameters = null, HttpMethod httpMethod = null, int? timeout = null)
            where TResult : class;

    }
}
