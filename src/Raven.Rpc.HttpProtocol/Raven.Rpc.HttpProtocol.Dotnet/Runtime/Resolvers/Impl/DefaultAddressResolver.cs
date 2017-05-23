using Raven.Rpc.HttpProtocol.Addresses;
using Raven.Rpc.HttpProtocol.Routing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raven.Rpc.HttpProtocol.Runtime.Resolvers.Impl
{
    /// <summary>
    /// 
    /// </summary>
    public class DefaultAddressResolver : IAddressResolver
    {
        private readonly IServiceRouteManager _serviceRouteManager;
        private readonly IAddressSelector _addressSelector;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        public async Task<HttpAddress> Resolver(string serviceId)
        {
            var descriptors = await _serviceRouteManager.GetRoutesAsync();
            var descriptor = descriptors.FirstOrDefault(i => i.ServiceDescriptor.Id == serviceId);

            if (descriptor == null)
            {
                //if (_logger.IsEnabled(LogLevel.Warning))
                //    _logger.LogWarning($"根据服务id：{serviceId}，找不到相关服务信息。");
                return null;
            }

            var address = new List<HttpAddress>();
            foreach (var addressModel in descriptor.Addresses)
            {
                //await _healthCheckService.Monitor(addressModel);
                //if (!await _healthCheckService.IsHealth(addressModel))
                //    continue;

                address.Add(addressModel);
            }
            var hasAddress = address.Any();
            if (!hasAddress)
            {
                //if (_logger.IsEnabled(LogLevel.Warning))
                //    _logger.LogWarning($"根据服务id：{serviceId}，找不到可用的地址。");
                return null;
            }

            return await _addressSelector.SelectAsync(new AddressSelectContext
            {
                Descriptor = descriptor.ServiceDescriptor,
                Address = address
            });

        }
    }
}
