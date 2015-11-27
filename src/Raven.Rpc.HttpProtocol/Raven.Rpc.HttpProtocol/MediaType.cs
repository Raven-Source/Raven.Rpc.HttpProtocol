using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Rpc.HttpProtocol
{
    public static class MediaType
    {
        public const string bytes = "application/bytes";
        public const string xml = "application/xml";
        public const string json = "application/json";
        public const string bson = "application/bson";
        public const string form = "application/x-www-form-urlencoded";
    }
}
