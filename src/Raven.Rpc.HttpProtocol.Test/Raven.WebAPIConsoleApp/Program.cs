using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.WebAPIConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = "http://192.168.2.12:9002/";
            using (Microsoft.Owin.Hosting.WebApp.Start<Startup>(host))
            {
                Console.WriteLine(host);
                Console.WriteLine("Press [enter] to quit...");
                Console.ReadLine();
            }
            
        }
    }
}
