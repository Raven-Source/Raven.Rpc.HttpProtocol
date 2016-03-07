using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Rpc.HttpProtocol
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRpcHttpClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="httpMethod"></param>
        /// <param name="urlParameters"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        TResult Invoke<TData, TResult>(string url, TData data = default(TData), IDictionary<string, string> urlParameters = null, HttpMethod httpMethod = null, int? timeout = null)
            where TResult : class;

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="url"></param>
        /// <param name="httpMethod"></param>
        /// <param name="urlParameters"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        TResult Invoke<TResult>(string url, IDictionary<string, string> urlParameters = null, HttpMethod httpMethod = null, int? timeout = null)
            where TResult : class;

        /// <summary>
        /// Get
        /// </summary>
        /// <typeparam name="TResult">返回数据类型</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        TResult Get<TResult>(string url, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where TResult : class;

        /// <summary>
        /// Post
        /// </summary>
        /// <typeparam name="TData">提交数据类型</typeparam>
        /// <typeparam name="TResult">返回数据类型</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="data">数据</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        TResult Post<TData, TResult>(string url, TData data, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where TResult : class;

        /// <summary>
        /// Post
        /// </summary>
        /// <typeparam name="TResult">返回数据类型</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="data">数据</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        TResult Post<TResult>(string url, byte[] data, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where TResult : class;

        /// <summary>
        /// Post
        /// </summary>
        /// <typeparam name="TResult">返回数据类型</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="data">数据</param>
        /// <param name="offset">偏移</param>
        /// <param name="count">数量</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        TResult Post<TResult>(string url, byte[] data, int offset, int count, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where TResult : class;

        /// <summary>
        /// Post
        /// </summary>
        /// <typeparam name="TResult">返回数据类型</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="data">数据</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        TResult Post<TResult>(string url, IDictionary<string, string> data, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where TResult : class;

        /// <summary>
        /// Put
        /// </summary>
        /// <typeparam name="TData">提交数据类型</typeparam>
        /// <typeparam name="TResult">返回数据类型</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="data">数据</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        TResult Put<TData, TResult>(string url, TData data, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where TResult : class;

        /// <summary>
        /// Put
        /// </summary>
        /// <typeparam name="TResult">返回数据类型</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="data">url parameter 数据</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        TResult Put<TResult>(string url, IDictionary<string, string> data, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where TResult : class;

        /// <summary>
        /// Delete
        /// </summary>
        /// <typeparam name="TResult">返回数据类型</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        TResult Delete<TResult>(string url, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where TResult : class;

    }
}
