﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;

namespace Raven.WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values/5
        [HttpGet]
        public string Get()
        {
            //return new ResponseModel<User>() { Data = new User { Name = "ResponseModel-Get" } };
            return "gg";
        }

        //// POST api/values
        //public ResponseModel Post([FromBody]ResponseModel value)
        //{
        //    value.Message += DateTime.Now.ToString();
        //    return value;
        //}

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
