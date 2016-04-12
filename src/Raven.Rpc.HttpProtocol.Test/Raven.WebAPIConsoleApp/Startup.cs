using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;

namespace Raven.WebAPIConsoleApp
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {

            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // 默认返回Json数据
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            //var bson = new BsonMediaTypeFormatter();
            //bson.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/bson"));
            //config.Formatters.Add(bson);
            config.Formatters.Add(new Raven.AspNet.WebApiExtensions.Formatters.MsgPackFormatter());

            appBuilder.UseRequestScopeContext();
            appBuilder.UseWebApi(config);
            
            //CallContext
            //appBuilder.Use(
        }
    }
}
