using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Raven.WebAPIConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = System.Configuration.ConfigurationManager.AppSettings["host"];
            using (Microsoft.Owin.Hosting.WebApp.Start<Startup>(host))
            {

                Console.WriteLine(host);
                Console.WriteLine("Press [enter] to quit...");
                Console.ReadLine();
            }


        }

    }
}
