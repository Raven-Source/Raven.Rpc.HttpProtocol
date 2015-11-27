using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Rpc.HttpProtocol
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class RpcHttpClient<RT> : IRpcHttpClient, IRpcHttpClientAsync
            where RT : class, new()
    {
        private string _baseUrl;
        private int _timeout;
        private MediaTypeFormatter _mediaTypeFormatter;
        private MediaTypeFormatter[] _mediaTypeFormatterArray = new MediaTypeFormatter[]
        {
            new FormUrlEncodedMediaTypeFormatter(),
            new XmlMediaTypeFormatter(),
            new BsonMediaTypeFormatter(),
            new JsonMediaTypeFormatter(),
        };

        private MediaTypeWithQualityHeaderValue _mediaTypeWithQualityHeaderValue;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="mediaType"></param>
        /// <param name="timeout">超时时间（毫秒）</param>
        public RpcHttpClient(string baseUrl, string mediaType = MediaType.json, int timeout = 10000)
        {
            this._baseUrl = baseUrl;
            this._timeout = timeout;
            _mediaTypeFormatter = CreateMediaTypeFormatter(mediaType);
            _mediaTypeWithQualityHeaderValue = new MediaTypeWithQualityHeaderValue(mediaType);
        }

        /// <summary>
        /// 创建MediaTypeFormatter
        /// </summary>
        /// <param name="mediaType"></param>
        /// <returns></returns>
        private MediaTypeFormatter CreateMediaTypeFormatter(string mediaType)
        {
            MediaTypeFormatter mediaTypeFormatter = null;
            switch (mediaType)
            {
                case MediaType.form:
                    mediaTypeFormatter = new FormUrlEncodedMediaTypeFormatter();
                    break;
                case MediaType.xml:
                    mediaTypeFormatter = new XmlMediaTypeFormatter();
                    break;
                case MediaType.bson:
                    mediaTypeFormatter = new BsonMediaTypeFormatter();
                    break;
                case MediaType.json:
                default:
                    mediaTypeFormatter = new JsonMediaTypeFormatter();
                    break;
            }

            return mediaTypeFormatter;
        }

        /// <summary>
        /// HttpClient初始化
        /// </summary>
        /// <param name="timeout"></param>
        /// <param name="client"></param>
        private void InitHttpClient(int? timeout, HttpClient client)
        {
            if (timeout.HasValue)
            {
                client.Timeout = TimeSpan.FromMilliseconds(timeout.Value);
            }
            else
            {
                client.Timeout = TimeSpan.FromMilliseconds(this._timeout);
            }

            client.BaseAddress = new Uri(this._baseUrl);
            client.DefaultRequestHeaders.Accept.Add(_mediaTypeWithQualityHeaderValue);
            client.DefaultRequestHeaders.Connection.Add("keep-alive");
            DefaultRequestHeadersHandler(client.DefaultRequestHeaders);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <typeparam name="T">返回数据类型</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public virtual T Get<T>(string url, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where T : class, new()
        {
            using (var client = new HttpClient())
            {
                InitHttpClient(timeout, client);

                string requestUrl = _baseUrl + url;
                CreateUrlParams(urlParameters, ref requestUrl);

                using (HttpResponseMessage response = client.GetAsync(requestUrl).Result)
                {
                    T result = GetResult<T>(response);
                    return result as T;
                }
            }
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <typeparam name="T">返回数据类型</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public virtual async Task<T> GetAsync<T>(string url, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where T : class, new()
        {
            using (var client = new HttpClient())
            {
                InitHttpClient(timeout, client);

                string requestUrl = _baseUrl + url;
                CreateUrlParams(urlParameters, ref requestUrl);

                using (HttpResponseMessage response = await client.GetAsync(requestUrl))
                {
                    T result = await GetResultAsync<T>(response);
                    return result as T;
                }
            }
        }

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
        public virtual T Post<D, T>(string url, D data, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where T : class, new()
        {
            using (var client = new HttpClient())
            {
                InitHttpClient(timeout, client);

                string requestUrl = _baseUrl + url;
                CreateUrlParams(urlParameters, ref requestUrl);

                using (HttpContent content = new ObjectContent<D>(data, _mediaTypeFormatter))
                {
                    using (HttpResponseMessage response = client.PostAsync(requestUrl, content).Result)
                    {
                        T result = GetResult<T>(response);
                        return result as T;
                    }
                }
            }
        }

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
        public virtual async Task<T> PostAsync<D, T>(string url, D data, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where T : class, new()
        {
            using (var client = new HttpClient())
            {
                InitHttpClient(timeout, client);

                string requestUrl = _baseUrl + url;
                CreateUrlParams(urlParameters, ref requestUrl);

                using (HttpContent content = new ObjectContent<D>(data, _mediaTypeFormatter))
                {
                    using (HttpResponseMessage response = await client.PostAsync(requestUrl, content))
                    {
                        T result = await GetResultAsync<T>(response);
                        return result as T;
                    }
                }
            }
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <typeparam name="T">返回数据类型</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="data">数据</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public virtual T Post<T>(string url, byte[] data, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where T : class, new()
        {
            return Post<T>(url, data, 0, data.Length, urlParameters, timeout);
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <typeparam name="T">返回数据类型</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="data">数据</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout">超时时间</param>
        /// <returns></returns>
        public virtual async Task<T> PostAsync<T>(string url, byte[] data, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where T : class, new()
        {
            return await PostAsync<T>(url, data, 0, data.Length, urlParameters, timeout);
        }

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
        public virtual T Post<T>(string url, byte[] data, int offset, int count, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where T : class, new()
        {
            using (var client = new HttpClient())
            {
                InitHttpClient(timeout, client);

                string requestUrl = _baseUrl + url;
                CreateUrlParams(urlParameters, ref requestUrl);

                using (HttpContent content = new ByteArrayContent(data, offset, count))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue(MediaType.bytes);
                    using (HttpResponseMessage response = client.PostAsync(requestUrl, content).Result)
                    {
                        T result = GetResult<T>(response);
                        return result as T;
                    }
                }
            }
        }

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
        public virtual async Task<T> PostAsync<T>(string url, byte[] data, int offset, int count, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where T : class, new()
        {
            using (var client = new HttpClient())
            {
                InitHttpClient(timeout, client);

                string requestUrl = _baseUrl + url;
                CreateUrlParams(urlParameters, ref requestUrl);

                using (HttpContent content = new ByteArrayContent(data, offset, count))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue(MediaType.bytes);
                    using (HttpResponseMessage response = await client.PostAsync(requestUrl, content))
                    {
                        T result = await GetResultAsync<T>(response);
                        return result as T;
                    }
                }
            }
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <typeparam name="T">返回数据类型</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="data">数据</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public virtual T Post<T>(string url, IDictionary<string, string> data, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where T : class, new()
        {
            using (var client = new HttpClient())
            {
                InitHttpClient(timeout, client);

                string requestUrl = _baseUrl + url;
                CreateUrlParams(urlParameters, ref requestUrl);

                using (HttpContent content = new ObjectContent<IDictionary<string, string>>(data, _mediaTypeFormatter))
                {
                    using (HttpResponseMessage response = client.PostAsync(requestUrl, content).Result)
                    {
                        T result = GetResult<T>(response);
                        return result as T;
                    }
                }
            }
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <typeparam name="T">返回数据类型</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="data">数据</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public virtual async Task<T> PostAsync<T>(string url, IDictionary<string, string> data, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where T : class, new()
        {
            using (var client = new HttpClient())
            {
                InitHttpClient(timeout, client);

                string requestUrl = _baseUrl + url;
                CreateUrlParams(urlParameters, ref requestUrl);

                using (HttpContent content = new ObjectContent<IDictionary<string, string>>(data, _mediaTypeFormatter))
                {
                    using (HttpResponseMessage response = await client.PostAsync(requestUrl, content))
                    {
                        T result = await GetResultAsync<T>(response);
                        return result as T;
                    }
                }
            }
        }

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
        public virtual T Put<D, T>(string url, D data, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where T : class, new()
        {
            using (var client = new HttpClient())
            {
                InitHttpClient(timeout, client);

                string requestUrl = _baseUrl + url;
                CreateUrlParams(urlParameters, ref requestUrl);

                using (HttpContent content = new ObjectContent<D>(data, _mediaTypeFormatter))
                {
                    using (HttpResponseMessage response = client.PutAsync(requestUrl, content).Result)
                    {
                        T result = GetResult<T>(response);
                        return result as T;
                    }
                }
            }
        }

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
        public virtual async Task<T> PutAsync<D, T>(string url, D data, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where T : class, new()
        {
            using (var client = new HttpClient())
            {
                InitHttpClient(timeout, client);

                string requestUrl = _baseUrl + url;
                CreateUrlParams(urlParameters, ref requestUrl);

                using (HttpContent content = new ObjectContent<D>(data, _mediaTypeFormatter))
                {
                    using (HttpResponseMessage response = await client.PutAsync(requestUrl, content))
                    {
                        T result = await GetResultAsync<T>(response);
                        return result as T;
                    }
                }
            }
        }

        /// <summary>
        /// Put
        /// </summary>
        /// <typeparam name="T">返回数据类型</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="data">url parameter 数据</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public virtual T Put<T>(string url, IDictionary<string, string> data, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where T : class, new()
        {
            using (var client = new HttpClient())
            {
                InitHttpClient(timeout, client);

                string requestUrl = _baseUrl + url;
                CreateUrlParams(urlParameters, ref requestUrl);

                using (HttpContent content = new ObjectContent<IDictionary<string, string>>(data, _mediaTypeFormatter))
                {
                    using (HttpResponseMessage response = client.PutAsync(requestUrl, content).Result)
                    {
                        T result = GetResult<T>(response);
                        return result as T;
                    }
                }
            }
        }

        /// <summary>
        /// Put
        /// </summary>
        /// <typeparam name="T">返回数据类型</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="data">url parameter 数据</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public virtual async Task<T> PutAsync<T>(string url, IDictionary<string, string> data, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where T : class, new()
        {
            using (var client = new HttpClient())
            {
                InitHttpClient(timeout, client);

                string requestUrl = _baseUrl + url;
                CreateUrlParams(urlParameters, ref requestUrl);

                using (HttpContent content = new ObjectContent<IDictionary<string, string>>(data, _mediaTypeFormatter))
                {
                    using (HttpResponseMessage response = await client.PutAsync(requestUrl, content))
                    {
                        T result = await GetResultAsync<T>(response);
                        return result as T;
                    }
                }
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <typeparam name="T">返回数据类型</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public virtual T Delete<T>(string url, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where T : class, new()
        {
            using (var client = new HttpClient())
            {
                InitHttpClient(timeout, client);

                string requestUrl = _baseUrl + url;
                CreateUrlParams(urlParameters, ref requestUrl);

                using (HttpResponseMessage response = client.DeleteAsync(requestUrl).Result)
                {
                    T result = GetResult<T>(response);
                    return result as T;
                }
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <typeparam name="T">返回数据类型</typeparam>
        /// <param name="url">请求Url</param>
        /// <param name="urlParameters">url parameter 数据</param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public virtual async Task<T> DeleteAsync<T>(string url, IDictionary<string, string> urlParameters = null, int? timeout = null)
            where T : class, new()
        {
            using (var client = new HttpClient())
            {
                InitHttpClient(timeout, client);

                string requestUrl = _baseUrl + url;
                CreateUrlParams(urlParameters, ref requestUrl);

                using (HttpResponseMessage response = await client.DeleteAsync(requestUrl))
                {
                    T result = await GetResultAsync<T>(response);
                    return result as T;
                }
            }
        }

        /// <summary>
        /// 创建参数
        /// </summary>
        /// <param name="urlParameters"></param>
        /// <param name="baseUrl"></param>
        private void CreateUrlParams(IDictionary<string, string> urlParameters, ref string baseUrl)
        {
            StringBuilder buffer = new StringBuilder();
            AddDefaultParameters(ref urlParameters);

            if (urlParameters != null)
            {
                int i = 0;
                foreach (string key in urlParameters.Keys)
                {
                    if (i == 0)
                    {
                        buffer.AppendFormat("{0}={1}", key, urlParameters[key]);
                        i++;
                    }
                    else
                    {
                        buffer.AppendFormat("&{0}={1}", key, urlParameters[key]);
                    }
                }
            }

            int index = baseUrl.IndexOf("?");
            if (index >= 0)
            {
                if (index < baseUrl.Length - 1)
                {
                    baseUrl += "&" + buffer.ToString();
                }
                else
                {
                    baseUrl += buffer.ToString();
                }
            }
            else
            {
                baseUrl += "?" + buffer.ToString();
            }
        }

        /// <summary>
        /// 获取Result对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        private T GetResult<T>(HttpResponseMessage response)
            where T : class, new()
        {
            T result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<T>(_mediaTypeFormatterArray).Result;
                return result;
            }
            else
            {
                result = default(T);
                ErrorResponseHandler<T>(ref result, response);
                return result;
            }
        }

        /// <summary>
        /// 获取Result对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        private async Task<T> GetResultAsync<T>(HttpResponseMessage response)
            where T : class, new()
        {
            T result;
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<T>(_mediaTypeFormatterArray);
                return result;
            }
            else
            {
                result = default(T);
                ErrorResponseHandler<T>(ref result, response);
                return result;
            }
        }
        /// <summary>
        /// 添加默认参数
        /// </summary>
        /// <param name="urlParameters"></param>
        private void AddDefaultParameters(ref IDictionary<string, string> urlParameters)
        {
            //系统参数
            if (urlParameters == null)
            {
                urlParameters = new Dictionary<string, string>();
            }

            IDictionary<string, string> dp = null;
            dp = FurnishDefaultParameters();

            if (dp != null && dp.Count > 0)
            {
                foreach (var item in dp)
                {
                    if (urlParameters.ContainsKey(item.Key)) continue;
                    urlParameters.Add(item);
                }
            }
        }

        /// <summary>
        /// 请求前，请求header定义
        /// </summary>
        /// <param name="headers"></param>
        protected virtual void DefaultRequestHeadersHandler(HttpRequestHeaders headers)
        {
        }

        /// <summary>
        /// 异常处理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <param name="httpResponse"></param>
        protected virtual void ErrorResponseHandler<T>(ref T result, HttpResponseMessage httpResponse)
            where T : class, new()
        {
        }

        /// <summary>
        /// 提供默认参数
        /// </summary>
        protected abstract IDictionary<string, string> FurnishDefaultParameters();

    }
}
