using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

namespace Raven.WebAPIConsoleApp.netcore
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .UseUrls("http://127.0.0.1:9002/")
                .Build();

            host.Run();
        }
    }
}
