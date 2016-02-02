using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Collections.Generic;
using Raven.WebAPI.Models;
using Raven.Rpc.HttpProtocol;

namespace Raven.Rpc.HttpProtocol.Test
{
    [TestClass]
    public class APIClientTest
    {
        [TestMethod]
        public void Get()
        {
            ValuesAPIClient valuesApi = new ValuesAPIClient(MediaType.msgpack);

            var result2 = valuesApi.Get<ResponseModel<User>>("api/Values/get");
            Assert.AreEqual(result2.Data.Name, "ResponseModel-Get");

            //ResponseModel result = new ResponseModel();
            //result.Message = "111";
            //result = valuesApi.Post<ResponseModel, ResponseModel>("api/Values/get", result);
            //Assert.AreEqual(result.Message.Substring(0,3), "111");



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
    }
}
