using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiLivraria.Controllers
{
    /// <summary>
    /// Efetua o pagamento
    /// </summary>
    [Produces("application/json")]
    [Route("api/Pagamento")]
    public class PagamentoController : Controller
    {
        /// <summary>
        /// Efetua o pagamento
        /// </summary>
        /// <param name="id">Id do pedido</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody]Guid id)
        {
            try
            {
                string uriServicolog = "http://localhost:60894/api/pagamento";
                var json = new
                {
                    id = id
                };

                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var content = new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json");
                var result = httpClient.PostAsync(uriServicolog, content).Result;
                if (result.IsSuccessStatusCode)
                {
                    return Ok("Pagamento Realizado Com sucesso.");
                }
                else {
                    return StatusCode(401);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}