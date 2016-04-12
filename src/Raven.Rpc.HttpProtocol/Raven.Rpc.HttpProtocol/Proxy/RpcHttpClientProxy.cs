using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Rpc.HttpProtocol
{
    public static class RpcHttpClientProxy
    {
        public static T Proxy<T>(this RpcHttpClient client, HttpMethod httpMethod = null, int? timeout = null)
        {
            throw new Exception();
        }
    }
}
