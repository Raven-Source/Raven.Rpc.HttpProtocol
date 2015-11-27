using Raven.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Raven.AspNetWebApiClient.Test
{
    public class ValuesAPIClient : WebAPIClient<ResponseModel>
    {

        public ValuesAPIClient(string mediaType)
            : base("http://192.168.2.15:9000/", timeout: 15000, mediaType: mediaType)
        {
        }
        
        protected override void DefaultRequestHeadersHandler(System.Net.Http.Headers.HttpRequestHeaders headers)
        {
            base.DefaultRequestHeadersHandler(headers);
        }

        protected override IDictionary<string, string> FurnishDefaultParameters()
        {
            return null;
        }

        protected override void ErrorResponseHandler<T>(ref T result, HttpResponseMessage httpResponse)
        {
            result = new ResponseModel() as T;
            base.ErrorResponseHandler<T>(ref result, httpResponse);
        }
    }
}
