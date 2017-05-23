using Raven.Rpc.HttpProtocol.Addresses;
using System.Threading.Tasks;

namespace Raven.Rpc.HttpProtocol.Runtime.Resolvers
{
    /// <summary>
    /// 一个抽象的服务地址解析器。
    /// </summary>
    public interface IAddressResolver
    {
        /// <summary>
        /// 解析服务地址。
        /// </summary>
        /// <param name="serviceId">服务Id。</param>
        /// <returns>服务地址模型。</returns>
        Task<HttpAddress> Resolver(string serviceId);
    }
}
