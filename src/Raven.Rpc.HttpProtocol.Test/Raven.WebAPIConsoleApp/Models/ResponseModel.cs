
namespace Raven.WebAPIConsoleApp.Models
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
