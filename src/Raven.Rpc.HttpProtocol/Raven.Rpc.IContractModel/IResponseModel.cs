using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Rpc.IContractModel
{
    /// <summary>
    /// IResponseModel
    /// </summary>
    /// <typeparam name="TCode"></typeparam>
    public interface IResponseModel<TCode>
    {
        /// <summary>
        /// 结果编码，1为成功
        /// </summary>
        TCode Code { get; set; }
    }

    /// <summary>
    /// IResponseModel
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    /// <typeparam name="TCode"></typeparam>
    public interface IResponseModel<TData, TCode> : IResponseModel<TCode>
    {
        /// <summary>
        /// 数据
        /// </summary>
        TData Data { get; set; }
    }

    /// <summary>
    /// ResponseModelBase
    /// </summary>
    public class ResponseModel : IResponseModel<int>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual int Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Ext")]
        public virtual KeyValue<string, string>[] Extension { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Msg")]
        public virtual string Message { get; set; }
    }

    /// <summary>
    /// ResponseModelBase
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class ResponseModel<TData> : ResponseModel, IResponseModel<TData, int>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual TData Data { get; set; }
    }


}
