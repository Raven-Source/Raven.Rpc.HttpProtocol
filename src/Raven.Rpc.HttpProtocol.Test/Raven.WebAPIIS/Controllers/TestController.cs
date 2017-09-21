using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Raven.WebAPI.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        public async Task<string> Get3()
        {
            int workerThreads, completionPortThreads;
            ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);
            return await Task.FromResult<string>("workerThreads:" + workerThreads + ",completionPortThreads:" + completionPortThreads);
        }
    }
}
