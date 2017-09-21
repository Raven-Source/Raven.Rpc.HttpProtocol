using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Rpc.HttpProtocol.Messages
{
    /// <summary>
    /// 
    /// </summary>
    public class InvokeResultMessage
    {
        /// <summary>
        /// 
        /// </summary>
        public string ExceptionMessage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object Result { get; set; }
    }
}
