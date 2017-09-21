using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Rpc.HttpProtocol
{
    /// <summary>
    /// IRpcHttpClientOptions
    /// </summary>
    public interface IRpcHttpClientOptions
    {
        /// <summary>
        /// base url
        /// </summary>
        string BaseUrl { get; set; }

        /// <summary>
        /// Encoding
        /// </summary>
        Encoding Encoding { get; set; }

        /// <summary>
        /// 
        /// </summary>
        HttpClientHandler Handler { get; set; }

        /// <summary>
        /// Raven.Rpc.HttpProtocol.MediaType
        /// </summary>
        string MediaType { get; set; }

        /// <summary>
        /// Milliseconds
        /// </summary>
        int Timeout { get; set; }

        /// <summary>
        /// 
        /// </summary>
        DecompressionMethods DecompressionMethods { get; set; }        

    }
}
