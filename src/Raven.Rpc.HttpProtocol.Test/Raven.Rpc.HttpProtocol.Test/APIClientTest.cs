using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Collections.Generic;
using Raven.WebAPI.Models;
using Raven.Rpc.HttpProtocol;
using System.Threading.Tasks;

namespace Raven.Rpc.HttpProtocol.Test
{
    [TestClass]
    public class APIClientTest
    {
        [TestMethod]
        public async Task Get()
        {
            ValuesAPIClient valuesApi = new ValuesAPIClient(MediaType.json);

            var result2 = valuesApi.Get<ResponseModel<User>>("api/Values/get");

            Assert.AreEqual(result2.Data.Name, "ResponseModel-Get");

            var a = valuesApi.Get<List<User>>("api/Values/get2");
            a = await valuesApi.GetAsync<List<User>>("api/Values/get2");

            a = valuesApi.Invoke<List<User>>("api/Values/get2", httpMethod: HttpMethod.Get);
            a = await valuesApi.InvokeAsync<List<User>>("api/Values/get2", httpMethod: HttpMethod.Get);

            //var result5 = await valuesApi.GetAsync<ResponseModel<User>>("api/Values/get3");


            //result = valuesApi.Get<Result>("api/Values/1");
            //;

            //result = valuesApi.Get<Result>("api/Values/1");
            //;

            //result = valuesApi.Get<Result>("api/Values/1");
            //;
            //var _baseUrl = "http://localhost:32303/";
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(_baseUrl);
            //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //    string requestUrl = _baseUrl + "api/values/Test";
            //    byte[] data = new byte[] { 1, 2, 3, 4, 5 };

            //    ByteArrayContent content = new ByteArrayContent(data);
            //    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/bytes");
            //    using (HttpResponseMessage response = client.PostAsync(requestUrl, content).Result)
            //    {

            //    }
            //}
        }

        [TestMethod]
        public async Task Post()
        {
            ValuesAPIClient valuesApi = new ValuesAPIClient(MediaType.json);

            ResponseModel result = new ResponseModel();
            result.Message = "111";
            var result2 = valuesApi.Post<ResponseModel, ResponseModel>("api/Values/Post", result);

            Assert.AreEqual(result2.Message.Substring(0, 3), "111");
            await valuesApi.PostAsync<ResponseModel, ResponseModel>("api/Values/Post", result);

            valuesApi.Invoke<ResponseModel, ResponseModel>("api/Values/Post", result);
            await valuesApi.InvokeAsync<ResponseModel, ResponseModel>("api/Values/Post", result);
        }
    }
}
