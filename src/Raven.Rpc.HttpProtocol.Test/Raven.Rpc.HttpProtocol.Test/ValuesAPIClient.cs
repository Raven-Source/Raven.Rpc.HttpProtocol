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
            : base("http://192.168.2.12:9001/", timeout: 15000, mediaType: mediaType)
        {
        }

        protected override void DefaultUrlParametersHandler(ref IDictionary<string, string> urlParameters)
        {
            base.DefaultUrlParametersHandler(ref urlParameters);
        }

        protected override void RequestContentDataHandler(ref object data)
        {
            base.RequestContentDataHandler(ref data);
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
