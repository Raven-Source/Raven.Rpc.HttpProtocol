using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Rpc.IContractModel
{
    /// <summary>
    /// IRequestModel
    /// </summary>
    /// <typeparam name="THeader"></typeparam>
    public interface IRequestModel<THeader, TBody>
    {
        /// <summary>
        /// 
        /// </summary>
        TBody Body { get; set; }

        /// <summary>
        /// 
        /// </summary>
        THeader Header { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class RequestModel<TBody> : IRequestModel<Header, TBody>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual TBody Body { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Header Header { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Header
    {
        /// <summary>
        /// 
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RpcID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TrackID { get; set; }

    }

}
