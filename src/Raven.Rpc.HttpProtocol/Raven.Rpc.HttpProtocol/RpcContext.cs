using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Rpc.HttpProtocol
{
    /// <summary>
    /// 
    /// </summary>
    public class RpcContext
    {
        /// <summary>
        /// 请求开始时间
        /// </summary>
        public DateTime SendStartTime;

        /// <summary>
        /// 响应时间
        /// </summary>
        public DateTime? ReceiveEndTime;

        /// <summary>
        /// 
        /// </summary>
        public DateTime? ExceptionTime;

        /// <summary>
        /// Request Model
        /// </summary>
        public object RequestModel;

        /// <summary>
        /// Response Model
        /// </summary>
        public object ResponseModel;

        /// <summary>
        /// Response Size
        /// </summary>
        public long ResponseSize;

        /// <summary>
        /// 是否已处理异常
        /// </summary>
        public bool ExceptionHandled;

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, object> Items;

        /// <summary>
        /// 
        /// </summary>
        public RpcContext()
        {
            Items = new Dictionary<string, object>();
            ExceptionHandled = false;
        }
    }
}
