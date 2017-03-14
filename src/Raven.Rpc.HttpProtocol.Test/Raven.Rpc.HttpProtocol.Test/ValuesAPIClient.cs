﻿using Raven.Rpc.HttpProtocol;
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
            : base("http://127.0.0.1:9002/", timeout: 15000, mediaType: mediaType, decompressionMethods: System.Net.DecompressionMethods.Deflate)
        {
            //this.OnRequest += ValuesAPIClient_OnRequest;
        }

        private void ValuesAPIClient_OnRequest(HttpRequestMessage request)
        {
        }
    }
}
