using Raven.WebAPIConsoleApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Raven.WebAPIWinS
{
    public partial class Service1 : ServiceBase
    {
        IDisposable webAppHost = null;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            webAppHost = Microsoft.Owin.Hosting.WebApp.Start<Startup>("http://192.168.2.45:9001");
            //using (Microsoft.Owin.Hosting.WebApp.Start<Startup>("http://192.168.2.45:9001"))
            //{
            //    Console.WriteLine("Press [enter] to quit...");
            //    Console.ReadLine();
            //}
        }

        protected override void OnStop()
        {
            if (webAppHost != null)
            {
                webAppHost.Dispose();
                webAppHost = null;
            }
        }
    }
}
