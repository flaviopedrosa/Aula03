using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAutenticacao.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAutenticacao.Controllers
{
    [Produces("application/json")]
    [Route("api/Autenticao")]
    public class AutenticaoController : Controller
    {
        /// <summary>
        /// Realiza a autenticação do usuario e retorna um token de controle
        /// </summary>
        /// <param name=""></param>
        public IActionResult Post([FromBody] Login login) {
            return Ok(new UsuarioAutenticado { Email = "joao@gmail.com", Token = (new Guid()).ToString(), IsAutenticado = true, Data = System.DateTime.Now });
        }
    }
}