using Raven.AspNetWebApiClient.IContractModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.AspNetWebApiClient.ContractModel
{
    public class ResponseModel : IResponseModel<Dictionary<string, string>, int>
    {
        public int Code
        {
            get;
            set;
        }

        public Dictionary<string, string> Data
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }
    }
}
