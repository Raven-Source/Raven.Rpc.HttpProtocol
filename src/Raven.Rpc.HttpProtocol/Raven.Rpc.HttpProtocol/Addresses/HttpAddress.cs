using System;

namespace Raven.Rpc.HttpProtocol.Addresses
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpAddress
    {
        /// <summary>
        /// 
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        public HttpAddress(Uri uri)
        {
            Uri = uri;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Uri.ToString();
        }
    }
}
