using Raven.Rpc.HttpProtocol;
using Raven.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Rpc.HttpProtocol.Test
{
    public class ValuesAPIClient : RpcHttpClient
    {

        public ValuesAPIClient(string mediaType)
            : base("http://localhost:9001/", timeout: 15000, mediaType: mediaType)
        {
        }
        
        protected override void DefaultRequestHeadersHandler(System.Net.Http.Headers.HttpRequestHeaders headers)
        {
            base.DefaultRequestHeadersHandler(headers);
        }
        
        protected override void ErrorResponseHandler<T>(ref T result, HttpResponseMessage httpResponse)
        {
            result = new ResponseModel() as T;
            base.ErrorResponseHandler<T>(ref result, httpResponse);
        }

    }
}
