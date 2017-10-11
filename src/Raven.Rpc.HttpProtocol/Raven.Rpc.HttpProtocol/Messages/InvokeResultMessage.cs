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
    public class InvokeResultMessage<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Exception { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public T Result { get; set; }
    }
}
