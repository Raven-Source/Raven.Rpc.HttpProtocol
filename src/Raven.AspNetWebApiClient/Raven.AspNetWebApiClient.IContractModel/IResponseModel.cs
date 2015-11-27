using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Raven.AspNetWebApiClient.IContractModel
{
    /// <summary>
    /// IResponseModel
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    /// <typeparam name="TCode"></typeparam>
    public interface IResponseModel<TData, TCode> : IResult<TCode>
    {
        /// <summary>
        /// 数据
        /// </summary>
        TData Data { get; set; }
    }

    /// <summary>
    /// ResponseModelBase
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    /// <typeparam name="TCode"></typeparam>
    public class ResponseModelBase<TData, TCode> : IResponseModel<TData, TCode>
    {
        /// <summary>
        /// 
        /// </summary>
        public TCode Code { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public TData Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Ext")]
        public KeyValue<string, string>[] Extension { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "Msg")]
        public string Message { get; set; }
    }
    

}
