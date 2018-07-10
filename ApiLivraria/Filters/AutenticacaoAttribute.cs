using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ApiLivraria.Filters
{
    public class AutenticacaoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string authenticateKey = context.HttpContext.Request.Headers["AuthenticateKey"];
            if (authenticateKey == null)
                context.Result = new JsonResult(new { HttpStatusCode.Unauthorized });
            else
            {

                string uriServicolog = "http://localhost:49911/api/login";
                var json = new
                {
                    UserID = authenticateKey
                };

                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json");
                var result = httpClient.PostAsync(uriServicolog, content).Result;

                if (String.IsNullOrEmpty(authenticateKey))
                {
                    base.OnActionExecuting(context);
                }

                base.OnActionExecuting(context);
            }
        }

    }
}
