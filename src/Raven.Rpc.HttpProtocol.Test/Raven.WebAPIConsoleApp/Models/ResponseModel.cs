using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Raven.WebAPI
{
    public class ResponseModel : Raven.AspNetWebApiClient.IContractModel.IResponseModel<object, int>
    {
        public int Code
        {
            get;
            set;
        }

        public object Data
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