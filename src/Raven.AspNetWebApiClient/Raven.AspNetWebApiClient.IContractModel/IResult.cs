using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.AspNetWebApiClient.IContractModel
{
    /// <summary>
    /// 
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// 错误消息
        /// </summary>
        string Message { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TCode"></typeparam>
    public interface IResult<TCode> : IResult
    {
        /// <summary>
        /// 结果编码，1为成功
        /// </summary>
        TCode Code { get; set; }
    }
}
