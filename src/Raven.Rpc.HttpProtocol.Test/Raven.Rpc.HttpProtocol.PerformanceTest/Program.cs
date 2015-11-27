using Raven.Rpc.HttpProtocol.Test;
using Raven.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Raven.Rpc.HttpProtocol.PerformanceTest
{
    class Program
    {
        static ValuesAPIClient valuesApi_json = new ValuesAPIClient(MediaType.json);
        static ValuesAPIClient valuesApi_bson = new ValuesAPIClient(MediaType.bson);
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Get();

            Console.ReadLine();
        }



        void Get()
        {
            int speed = 10000;
            var result2 = valuesApi_json.GetAsync<ResponseModel>("api/Values/Get/1").Result;
            var result3 = valuesApi_bson.GetAsync<ResponseModel>("api/Values/Get/1").Result;
            Stopwatch sw = new Stopwatch();

            List<Task> taskList = new List<Task>();

            Thread.Sleep(5000);
            taskList.Clear();
            for (var i = 0; i < speed; i++)
            {
                var task = valuesApi_json.GetAsync<ResponseModel>("api/Values/Get/1", timeout: 15000);
                taskList.Add(task);
            }
            sw.Restart();
            Task.WaitAll(taskList.ToArray());
            sw.Stop();
            Console.WriteLine("valuesApi_json:GetAsync:" + sw.ElapsedMilliseconds.ToString());

            Thread.Sleep(5000);
            taskList.Clear();
            for (var i = 0; i < speed; i++)
            {
                var task = valuesApi_bson.GetAsync<ResponseModel>("api/Values/Get/1", timeout: 15000);
                taskList.Add(task);
            }
            sw.Restart();
            Task.WaitAll(taskList.ToArray());
            sw.Stop();
            Console.WriteLine("valuesApi_bson:GetAsync:" + sw.ElapsedMilliseconds.ToString());

        }
    }
}
