using Raven.Rpc.HttpProtocol.Addresses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Raven.Rpc.HttpProtocol.Routing
{
    /// <summary>
    /// 地址选择上下文。
    /// </summary>
    public class AddressSelectContext
    {
        /// <summary>
        /// 服务描述符。
        /// </summary>
        public ServiceDescriptor Descriptor { get; set; }

        /// <summary>
        /// 服务可用地址。
        /// </summary>
        public IEnumerable<HttpAddress> Address { get; set; }
    }

    /// <summary>
    /// 一个抽象的地址选择器。
    /// </summary>
    public interface IAddressSelector
    {
        /// <summary>
        /// 选择一个地址。
        /// </summary>
        /// <param name="context">地址选择上下文。</param>
        /// <returns>地址模型。</returns>
        Task<HttpAddress> SelectAsync(AddressSelectContext context);
    }
}
