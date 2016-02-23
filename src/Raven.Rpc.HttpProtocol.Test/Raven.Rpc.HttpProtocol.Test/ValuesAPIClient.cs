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
            this.OnRequest += ValuesAPIClient_OnRequest;
            this.OnResponse += ValuesAPIClient_OnResponse;
            this.OnError += ValuesAPIClient_OnError;
            this.RequestContentDataHandler += ValuesAPIClient_RequestContentDataHandler;
            this.ErrorResponseHandler += ValuesAPIClient_ErrorResponseHandler;
        }

        private object ValuesAPIClient_ErrorResponseHandler(Exception arg)
        {
            return null;
        }

        private object ValuesAPIClient_RequestContentDataHandler(object data)
        {
            return data;
        }

        private bool ValuesAPIClient_OnError(Exception arg)
        {
            return true;
        }

        private void ValuesAPIClient_OnRequest(HttpRequestMessage obj)
        {
            obj.Headers.Add("gg", "xx");
        }

        private void ValuesAPIClient_OnResponse(HttpResponseMessage arg1, object arg2)
        {
            ;
        }
        

    }
}
