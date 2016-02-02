using Raven.Rpc.IContractModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Raven.WebAPI.Models
{
    public class ResponseModel : Raven.Rpc.IContractModel.ResponseModel<int>
    {
    }

    public class ResponseModel<T> : Raven.Rpc.IContractModel.ResponseModel<T, int>
    {
        public ResponseModel() : base()
        {
        }
    }


    public class User
    {
        public long ID
        {
            get; set;
        }

        public string Name { get; set; }
    }
}