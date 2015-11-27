using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.AspNetWebApiClient
{
    public interface IWebAPIClient
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <typeparam name="T">返回数据类型</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        T Get<T>(string url, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where T : class, new();

        /// <summary>
        /// Post
        /// </summary>
        /// <typeparam name="D">提交数据类型</typeparam>
        /// <typeparam name="T">返回数据类型</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="data">数据</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        T Post<D, T>(string url, D data, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where T : class, new();

        /// <summary>
        /// Post
        /// </summary>
        /// <typeparam name="T">返回数据类型</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="data">数据</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        T Post<T>(string url, byte[] data, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where T : class, new();

        /// <summary>
        /// Post
        /// </summary>
        /// <typeparam name="T">返回数据类型</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="data">数据</param>
        /// <param name="offset">偏移</param>
        /// <param name="count">数量</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        T Post<T>(string url, byte[] data, int offset, int count, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where T : class, new();

        /// <summary>
        /// Post
        /// </summary>
        /// <typeparam name="T">返回数据类型</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="data">数据</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        T Post<T>(string url, IDictionary<string, string> data, IDictionary<string, string> urlParameters = null, int? timeout = null)
             where T : class, new();

        /// <summary>
        /// Put
        /// </summary>
        /// <typeparam name="D">提交数据类型</typeparam>
        /// <typeparam name="T">返回数据类型</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="data">数据</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        T Put<D, T>(string url, D data, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where T : class, new();

        /// <summary>
        /// Put
        /// </summary>
        /// <typeparam name="T">返回数据类型</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="data">url parameter 数据</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        T Put<T>(string url, IDictionary<string, string> data, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where T : class, new();

        /// <summary>
        /// Delete
        /// </summary>
        /// <typeparam name="T">返回数据类型</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        T Delete<T>(string url, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where T : class, new();
    }
}
