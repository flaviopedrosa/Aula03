using System;
using System.Linq;

using ApiLivraria.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiLivraria.Controllers
{
    [Route("public/v1/[controller]")]
    public class PedidoController : Controller
    {
        private readonly LivrariaContext _context;

        public PedidoController(LivrariaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Recupera detalhes de um pedido em especifico informado atraves da chave.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<controller>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(502)]
        [ProducesResponseType(504)]
        public IActionResult Get(Guid id)
        {
            try
            {
                Pedido model = _context.Pedidos.Where(x => x.Id == id).SingleOrDefault();
                if (model == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(model);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // POST api/<controller>
        /// <summary>
        /// Adiciona um novo livro ao pedido
        /// </summary>
        /// <param name="model">Modelo de Livro</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [Route("{id}/Livro")]
        public IActionResult Post([FromBody]Guid id, Livro model)
        {
            try
            {
                _context.Pedidos.Where(x=>x.Id==id).SingleOrDefault().Livros.Add(model);
                return StatusCode(201);

            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }



        // DELETE api/<controller>/5
        /// <summary>
        /// Exclui um livro existente no pedido.
        /// </summary>
        /// <param name="model">Modelo de Livro</param>
        /// <returns></returns>
        [HttpDelete()]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [Route("{id}/Livro")]
        public IActionResult Delete(Guid id, string isbn)
        {
            try
            {
                _context.CarrinhosCompras.
                    SingleOrDefault(x => x.Id == id)
                    .Livros
                    .Remove(new Livro { Isbn = isbn });

                return StatusCode(200);

            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
