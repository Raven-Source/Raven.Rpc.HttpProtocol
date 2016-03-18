using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Rpc.HttpProtocol.Util
{
    internal static class CompressionHelper
    {
        /// <summary>
        /// 
        /// </summary>
        private static Dictionary<string, CompressionType> dict = new Dictionary<string, CompressionType>
        {
            {  nameof(CompressionType.Deflate).ToLower(), CompressionType.Deflate },
            {  nameof(CompressionType.GZip).ToLower(), CompressionType.GZip },
            {  nameof(CompressionType.Zlib).ToLower(), CompressionType.Zlib }
        };

        //public static byte[] DeflateByte(byte[] str, CompressionType compressionType)
        //{
        //    if (str == null)
        //    {
        //        return null;
        //    }

        //    using (var output = new MemoryStream())
        //    {
        //        switch (compressionType)
        //        {
        //            case CompressionType.Deflate:
        //                using (
        //                    var compressor = new Ionic.Zlib.DeflateStream(
        //                    output, Ionic.Zlib.CompressionMode.Compress,
        //                    Ionic.Zlib.CompressionLevel.BestSpeed))
        //                {                            
        //                    compressor.Write(str, 0, str.Length);
        //                }
        //                break;
        //            case CompressionType.GZip:
        //                using (
        //                    var compressor = new Ionic.Zlib.GZipStream(
        //                    output, Ionic.Zlib.CompressionMode.Compress,
        //                    Ionic.Zlib.CompressionLevel.BestSpeed))
        //                {
        //                    compressor.Write(str, 0, str.Length);
        //                }
        //                break;
        //            case CompressionType.Zlib:
        //                using (
        //                    var compressor = new Ionic.Zlib.ZlibStream(
        //                    output, Ionic.Zlib.CompressionMode.Compress,
        //                    Ionic.Zlib.CompressionLevel.BestSpeed))
        //                {
        //                    compressor.Write(str, 0, str.Length);
        //                }
        //                break;
        //        }

        //        return output.ToArray();
        //    }
        //}

        public static byte[] Uncompress(byte[] data, CompressionType compressionType)
        {
            switch (compressionType)
            {
                case CompressionType.Deflate:
                    return Ionic.Zlib.DeflateStream.UncompressBuffer(data);
                case CompressionType.GZip:
                    return Ionic.Zlib.GZipStream.UncompressBuffer(data);
                case CompressionType.Zlib:
                    return Ionic.Zlib.ZlibStream.UncompressBuffer(data);
                default:
                    return data;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static CompressionType GetCompressionType(ICollection<string> contentType)
        {
            if (contentType == null || contentType.Count == 0)
            {
                return CompressionType.None;
            }

            CompressionType compressionType = CompressionType.None;
            //encoding = "deflate";
            foreach (var e in contentType)
            {
                var value = e.ToLower();
                if (dict.TryGetValue(value, out compressionType))
                {
                    //encoding = value;
                    break;
                }
            }

            return compressionType;
        }
    }

    /// <summary>
    /// Compression Type
    /// deflate,gzip,zlib
    /// </summary>
    public enum CompressionType : int
    {
        None = 0,
        Deflate = 1,
        GZip = 2,
        Zlib = 3
    }

}
