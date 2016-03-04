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
    public interface IResponseModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string GetCode();
    }

    /// <summary>
    /// IResponseModel
    /// </summary>
    /// <typeparam name="TCode"></typeparam>
    public interface IResponseModel<TCode> : IResponseModel
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
    /// ResponseModel
    /// </summary>
    /// <typeparam name="TCode"></typeparam>
    public class ResponseModel<TCode> : IResponseModel<TCode>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual TCode Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual List<KeyValue<string, string>> Extension { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string GetCode()
        {
            if (Code is Enum)
            {
                return Convert.ToInt32(Code).ToString();
            }
            return this.Code.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        public ResponseModel()
        {
            Extension = new List<KeyValue<string, string>>();
        }
    }

    /// <summary>
    /// ResponseModel
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    /// <typeparam name="TCode"></typeparam>
    public class ResponseModel<TData, TCode> : ResponseModel<TCode>, IResponseModel<TData, TCode>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual TData Data { get; set; }
    }

    ///// <summary>
    ///// ResponseModelBase
    ///// </summary>
    //public class ResponseModel<TData> : ResponseModel<TData, int>
    //{
    //}

}
