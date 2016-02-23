using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Rpc.HttpProtocol.WinAppTest
{
    //Raven.Rpc.IContractModel.RequestModel
    public class ResponseModel : Raven.Rpc.IContractModel.ResponseModel<object, int>
    {
    }

    public class APIClient : RpcHttpClient
    {

        public APIClient(string mediaType)
            : base("", timeout: 15000, mediaType: mediaType)
        {
        }

        //protected override void DefaultRequestHeadersHandler(System.Net.Http.Headers.HttpRequestHeaders headers)
        //{
        //    base.DefaultRequestHeadersHandler(headers);
        //}
        
        //protected override void ErrorResponseHandler<T>(ref T result, HttpResponseMessage httpResponse)
        //{
        //    base.ErrorResponseHandler<T>(ref result, httpResponse);
        //}
    }
}
