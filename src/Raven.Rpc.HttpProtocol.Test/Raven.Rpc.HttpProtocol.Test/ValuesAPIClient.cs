using Raven.Rpc.HttpProtocol;
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
        static string host = System.Configuration.ConfigurationManager.AppSettings["host"];
        public ValuesAPIClient(string mediaType)
            : base("", timeout: 15000, mediaType: mediaType, decompressionMethods: System.Net.DecompressionMethods.Deflate)
        {
            //this.OnRequest += ValuesAPIClient_OnRequest;
        }

        private void ValuesAPIClient_OnRequest(HttpRequestMessage request)
        {
        }
    }
}
