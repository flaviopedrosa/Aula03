using System;
using System.Linq;
using ApiLivraria.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiLivraria.Controllers
{
    [Route("public/v1/Livro/{isbn}/[controller]")]
    public class ComentarioController : Controller
    {
        private readonly LivrariaContext _context;

        public ComentarioController(LivrariaContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adiciona um comentário a um determinado livro.
        /// </summary>
        /// <param name="model">Comentário</param>
        /// <param name="isbn">Isbn do livro a receber o comentário</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody]string isbn, Comentario model)
        {
            try
            {
                _context.Comentarios.Add(model);

                return StatusCode(201);

            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Adiciona um comentário a um determinado livro.
        /// </summary>
        /// <param name="isbn">Isbn do livro a receber o comentário</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult Get([FromBody]string isbn)
        {
            try
            {
                var listaDecomentarios = _context.Comentarios.Where(x=>x.Livro.Isbn == isbn).ToList();
                if (listaDecomentarios == null)
                    return NoContent();
                else
                    return Ok(listaDecomentarios);

            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
