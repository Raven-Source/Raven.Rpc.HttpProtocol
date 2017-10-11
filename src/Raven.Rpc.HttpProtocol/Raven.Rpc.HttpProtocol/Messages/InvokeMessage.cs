
namespace Raven.Rpc.HttpProtocol.Messages
{
    /// <summary>
    /// 
    /// </summary>
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
