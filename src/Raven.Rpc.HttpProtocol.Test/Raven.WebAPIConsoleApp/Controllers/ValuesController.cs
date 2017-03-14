using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Web;
using Owin;
using Raven.WebAPIConsoleApp.Models;

namespace Raven.WebAPI.Controllers
{
    //[Raven.AspNet.WebApiExtensions.Attributes.Compression]
    public class ValuesController : ApiController
    {
        // GET api/values/5
        [HttpGet]
        public ResponseModel<User> Get()
        {
            return new ResponseModel<User>() { Data = new User { Name = "ResponseModel-Get" } };
        }

        [HttpGet]
        public List<User> Get2()
        {
            List<User> list = new List<User>();
            list.Add(new User() { Name = Guid.NewGuid().ToString() });
            list.Add(new User() { Name = Guid.NewGuid().ToString() });
            list.Add(new User() { Name = Guid.NewGuid().ToString() });
            list.Add(new User() { Name = Guid.NewGuid().ToString() });
            list.Add(new User() { Name = Guid.NewGuid().ToString() });
            //throw new Exception("aa");
            return list;
        }

        [HttpGet]
        public string Get3()
        {
            return "hello";
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
            //actionContext.Request.RequestUri.DnsSafeHost
            base.OnActionExecuting(actionContext);
        }
    }

}
