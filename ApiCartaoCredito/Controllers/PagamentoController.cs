using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiCartaoCredito.Controllers
{
    [Route("api/[controller]")]
    public class PagamentoController : Controller
    {
        
        
        [HttpPost]
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
        public IActionResult Post([FromBody]Decimal value)
        {
            return Ok("Pagameno aceito");
        }

      
    }
}
