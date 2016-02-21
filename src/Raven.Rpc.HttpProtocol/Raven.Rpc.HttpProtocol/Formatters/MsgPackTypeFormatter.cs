using Raven.Serializer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Rpc.HttpProtocol.Formatters
{
    /// <summary>
    /// MediaType:"application/msgpack"
    /// </summary>
    public class MsgPackTypeFormatter : MediaTypeFormatter
    {
        private static readonly Lazy<IDataSerializer> serializerLazy = new Lazy<IDataSerializer>(() => SerializerFactory.Create(SerializerType.MsgPack));

        private static IDataSerializer Serializer
        {
            get
            {
                return serializerLazy.Value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public MsgPackTypeFormatter()
        {
            SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/msgpack"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override bool CanReadType(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override bool CanWriteType(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="readStream"></param>
        /// <param name="content"></param>
        /// <param name="formatterLogger"></param>
        /// <returns></returns>
        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, System.Net.Http.HttpContent content, IFormatterLogger formatterLogger)
        {
            var obj = Serializer.Deserialize(type, readStream);
            return Task.FromResult(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="writeStream"></param>
        /// <param name="content"></param>
        /// <param name="transportContext"></param>
        /// <returns></returns>
        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, System.Net.Http.HttpContent content, TransportContext transportContext)
        {
            Serializer.Serialize(value, writeStream);
            return writeStream.FlushAsync();
        }

    }
}
