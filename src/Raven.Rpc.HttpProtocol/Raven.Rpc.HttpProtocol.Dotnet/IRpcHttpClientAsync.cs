using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Raven.Rpc.HttpProtocol
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRpcHttpClientAsync
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="relativeUrl"></param>
        /// <param name="contentData"></param>
        /// <param name="httpMethod"></param>
        /// <param name="urlParameters"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        Task<TResult> InvokeAsync<TData, TResult>(string  relativeUrl, TData contentData = default(TData), IDictionary<string, string> urlParameters = null, HttpMethod httpMethod = null, int? timeout = null)
            where TResult : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="relativeUrl"></param>
        /// <param name="httpMethod"></param>
        /// <param name="urlParameters"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        Task<TResult> InvokeAsync<TResult>(string  relativeUrl, IDictionary<string, string> urlParameters = null, HttpMethod httpMethod = null, int? timeout = null)
            where TResult : class;

        /// <summary>
        /// GetAsync
        /// </summary>
        /// <typeparam name="TResult">返回数据类型</typeparam>
        /// <param name="relativeUrl">请求Url</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        Task<TResult> GetAsync<TResult>(string  relativeUrl, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where TResult : class;

        /// <summary>
        /// Post
        /// </summary>
        /// <typeparam name="TData">提交数据类型</typeparam>
        /// <typeparam name="TResult">返回数据类型</typeparam>
        /// <param name="relativeUrl">请求Url</param>
        /// <param name="contentData">数据</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        Task<TResult> PostAsync<TData, TResult>(string  relativeUrl, TData contentData, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where TResult : class;

        /// <summary>
        /// Post
        /// </summary>
        /// <typeparam name="TResult">返回数据类型</typeparam>
        /// <param name="relativeUrl">请求Url</param>
        /// <param name="contentData">数据</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        Task<TResult> PostAsync<TResult>(string  relativeUrl, byte[] contentData, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where TResult : class;

        /// <summary>
        /// Post
        /// </summary>
        /// <typeparam name="TResult">返回数据类型</typeparam>
        /// <param name="relativeUrl">请求Url</param>
        /// <param name="contentData">数据</param>
        /// <param name="offset">偏移</param>
        /// <param name="count">数量</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        Task<TResult> PostAsync<TResult>(string  relativeUrl, byte[] contentData, int offset, int count, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where TResult : class;

        /// <summary>
        /// Post
        /// </summary>
        /// <typeparam name="TResult">返回数据类型</typeparam>
        /// <param name="relativeUrl">请求Url</param>
        /// <param name="contentData">数据</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        Task<TResult> PostAsync<TResult>(string  relativeUrl, IDictionary<string, string> contentData, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where TResult : class;

        /// <summary>
        /// Put
        /// </summary>
        /// <typeparam name="TData">提交数据类型</typeparam>
        /// <typeparam name="TResult">返回数据类型</typeparam>
        /// <param name="relativeUrl">请求Url</param>
        /// <param name="contentData">数据</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        Task<TResult> PutAsync<TData, TResult>(string  relativeUrl, TData contentData, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where TResult : class;

        /// <summary>
        /// Put
        /// </summary>
        /// <typeparam name="TResult">返回数据类型</typeparam>
        /// <param name="relativeUrl">请求Url</param>
        /// <param name="contentData">url parameter 数据</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        Task<TResult> PutAsync<TResult>(string  relativeUrl, IDictionary<string, string> contentData, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where TResult : class;

        /// <summary>
        /// Delete
        /// </summary>
        /// <typeparam name="TResult">返回数据类型</typeparam>
        /// <param name="relativeUrl">请求Url</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        Task<TResult> DeleteAsync<TResult>(string  relativeUrl, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where TResult : class;

    }
}
