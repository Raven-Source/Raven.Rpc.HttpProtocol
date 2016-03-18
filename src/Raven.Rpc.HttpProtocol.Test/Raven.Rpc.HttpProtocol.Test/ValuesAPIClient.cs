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
            : base("http://192.168.2.12:9002/", timeout: 15000, mediaType: mediaType, decompressionMethods: System.Net.DecompressionMethods.Deflate)
        {
            this.OnRequest += ValuesAPIClient_OnRequest;
        }

        private void ValuesAPIClient_OnRequest(HttpRequestMessage request)
        {
        }
    }
}
