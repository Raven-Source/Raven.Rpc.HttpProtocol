using System.Net;
using System.Net.Http;
using System.Text;

namespace Raven.Rpc.HttpProtocol
{
    /// <summary>
    /// RpcHttpClient 配置选项
    /// </summary>
    public class RpcHttpClientOptions : IRpcHttpClientOptions
    {
        /// <summary>
        /// base url
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Encoding
        /// </summary>
        public Encoding Encoding { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public HttpClientHandler Handler { get; set; }

        /// <summary>
        /// Raven.Rpc.HttpProtocol.MediaType
        /// </summary>
        public string MediaType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DecompressionMethods DecompressionMethods { get; set; }
        
    }
}
