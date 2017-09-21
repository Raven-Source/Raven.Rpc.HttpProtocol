using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Rpc.HttpProtocol.Messages
{
    public class InvokeMessage
    {
        /// <summary>
        /// 服务Id
        /// </summary>
        public string ServiceId { get; set; }

        /// <summary>
        /// 调用Id
        /// </summary>
        public string InvokeId { get; set; }

    }
}
