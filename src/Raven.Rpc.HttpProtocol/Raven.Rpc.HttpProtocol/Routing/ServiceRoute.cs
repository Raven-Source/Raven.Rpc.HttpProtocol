using Raven.Rpc.HttpProtocol.Addresses;
using System;
using System.Collections.Generic;

namespace Raven.Rpc.HttpProtocol.Routing
{
    /// <summary>
    /// 服务路由
    /// </summary>
    public class ServiceRoute
    {
        /// <summary>
        /// 服务可用地址。
        /// </summary>
        public IEnumerable<HttpAddress> Addresses { get; set; }

        /// <summary>
        /// 服务描述符。
        /// </summary>
        public ServiceDescriptor ServiceDescriptor { get; set; }
    }

}
