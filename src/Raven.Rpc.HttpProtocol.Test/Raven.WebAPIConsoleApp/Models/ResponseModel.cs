using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.WebAPIConsoleApp.Models
{
    public class ResponseModel : Rpc.IContractModel.ResponseModel<int>
    {
    }

    public class ResponseModel<T> : Rpc.IContractModel.ResponseModel<T, int>
    {
    }

    public class User
    {
        public long ID { get; set; }

        public string Name { get; set; }
    }
}
