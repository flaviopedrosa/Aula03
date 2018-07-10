using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ApiLivraria.Services
{
    public static class LogService
    {
        public static void Criar(string uri, string userId)
        {
            string uriServicolog = "http://localhost:60732/api/Log";
            var json = new
            {
                Uri = uri,
                UserId = userId
            };

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var content = new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(uriServicolog, content).Result;
            
        }
    }
}
