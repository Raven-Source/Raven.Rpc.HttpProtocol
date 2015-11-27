using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Collections.Generic;
using Raven.WebAPI.Models;

namespace Raven.AspNetWebApiClient.Test
{
    [TestClass]
    public class APIClientTest
    {
        [TestMethod]
        public void Get()
        {
            ValuesAPIClient valuesApi = new ValuesAPIClient(MediaType.json);
            ResponseModel result;
            try
            {
                result = valuesApi.Get<ResponseModel>("api/Values/get/1", new Dictionary<string, string> { { "x", "b" }, { "y", "a" } });
                ;
            }
            catch (Exception ex)
            {
                ;
            }

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
