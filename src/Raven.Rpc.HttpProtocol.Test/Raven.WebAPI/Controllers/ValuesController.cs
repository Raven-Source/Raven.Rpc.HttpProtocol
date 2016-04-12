using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using Raven.WebAPI.Models;
using Raven.Rpc.HttpProtocol;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;

namespace Raven.WebAPIConsoleApp.Controllers
{
    public class ValuesAPIClient : RpcHttpClient
    {

        public ValuesAPIClient()
            : base("http://localhost:24750/", timeout: 15000, decompressionMethods: System.Net.DecompressionMethods.Deflate)
        {
            this.OnRequest += ValuesAPIClient_OnRequest;
            this.OnResponse += ValuesAPIClient_OnResponse;
        }

        private void ValuesAPIClient_OnResponse(HttpResponseMessage response, RpcContext rpcContext)
        {
            var cc = CallContext.LogicalGetData("cc");
            ;
        }

        private void ValuesAPIClient_OnRequest(HttpRequestMessage request)
        {
            var cc = CallContext.LogicalGetData("cc");
            ;
        }

        public Task<ResponseModel> Get()
        {
            return base.InvokeAsync<ResponseModel, ResponseModel>("api/values/post", new ResponseModel() { }).ContinueWith(x => 
            {
                var aa = x.Result;
                aa.Code = 1;
                return aa;
            });

        }

        public async Task<ResponseModel> Get2(IDictionary<string, object> dict)
        {
            CallContext.LogicalSetData("cc", "dd");

            //System.Web.HttpContext.Current.Items.Add("cc", "dd");
            var aa = await base.InvokeAsync<ResponseModel, ResponseModel>("api/values/post", new ResponseModel() { }).ConfigureAwait(false);
            aa.Code = 1;

            var cc = CallContext.LogicalGetData("cc");

            return aa;

        }


        public Task<ResponseModel> Get3()
        {
            return base.InvokeAsync<ResponseModel, ResponseModel>("api/values/post", new ResponseModel() { });
        }
    }

    public class ValuesController : ApiController
    {
        // GET api/values/5
        //[HttpPost]
        //[HttpGet]
        //public ResponseModel<User> Get()
        //{
        //    return new ResponseModel<User>() { Data = new User { Name = "ResponseModel-Get" } };
        //}

        [HttpGet]
        public string Get()
        {
            System.Web.HttpContext.Current.Items.Add("aa", "bb");
            var client = new ValuesAPIClient();
            ResponseModel r = null;
            //r = client.InvokeAsync<ResponseModel, ResponseModel>("api/values/post", new ResponseModel() { }).Result;
            r = client.Get2(Request.GetOwinEnvironment()).Result;

            var dd = Request.GetOwinEnvironment();

            //System.Web.HttpContext.Current.GetOwinContext();
            //return new ResponseModel<User>() { Data = new User { Name = "ResponseModel-Get" } };
            return "gg";
        }


        [HttpGet]
        public async Task<string> Get2()
        {
            var client = new ValuesAPIClient();
            ResponseModel r = null;
            r = await client.InvokeAsync<ResponseModel, ResponseModel>("api/values/post", new ResponseModel() { });
            r = await client.Get2(Request.GetOwinEnvironment());

            //System.Web.HttpContext.Current.GetOwinContext();
            //return new ResponseModel<User>() { Data = new User { Name = "ResponseModel-Get" } };
            return "gg";
        }


        // POST api/values
        public ResponseModel Post([FromBody]ResponseModel value)
        {
            value.Message += DateTime.Now.ToString();
            return value;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        [HttpGet]
        public void Test()
        {
            int a = Convert.ToInt32("g");
        }


    }

    public class BytesDataAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {


            base.OnActionExecuting(actionContext);
        }
    }

}
