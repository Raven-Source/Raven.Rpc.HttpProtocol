using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raven.WebAPIConsoleApp.netcore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // 注入MVC框架
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            // 添加MVC中间件
            app.UseMvc(routes => 
            {
                routes.MapRoute("default", "api/{controller}/{action}/{id?}");
            });
            Console.WriteLine("UseMvc..");
            //app.Run(context =>
            //{
            //    return context.Response.WriteAsync("Hello from ASP.NET Core!");
            //});
        }
    }
}
