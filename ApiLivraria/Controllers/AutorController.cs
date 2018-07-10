using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiLivraria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLivraria.Controllers
{
    [Produces("application/json")]
    [Route("api/Autor")]
    public class AutorController : Controller
    {
        private readonly LivrariaContext _context;

        public AutorController(LivrariaContext context)
        {
            _context = context;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="offset"></param>
        /// <param name="quantidade"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [ProducesResponseType(502)]
        [ProducesResponseType(504)]
        public IActionResult Get(String nome, int offset = 0, int quantidade = 20)
        {
            try
            {
                var autores = _context.Autores.Where(x =>
                                                    (x.Nome.Contains(nome) || nome == null)
                                                    ).OrderBy(x=>x.Nome)
                                                    .Skip(offset)
                                                    .Take(quantidade)
                                                    .ToList();
                if (autores == null)
                    return NoContent();
                else
                    return Ok(autores);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Autor/5
        [HttpGet("{id}", Name = "Get")]
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
                Autor autor = _context.Autores.Find(id);
                if (autor == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(autor);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // POST: api/Autor
        /// <summary>
        /// Cria um novo registro referente à autor.
        /// </summary>
        /// <param name="model">Modelo de autor</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody]Autor model)
        {
            try
            {
                _context.Autores.Add(model);
                _context.SaveChanges();
                return StatusCode(201);

            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // PUT api/<controller>/5
        /// <summary>
        /// Altera um autor previamente existente na base de dados.
        /// </summary>
        /// <param name="model">Modelo de autor</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult Put(Guid id, [FromBody]Autor model)
        {
            try
            {
              
                _context.Autores.Update(model);
                return StatusCode(200);

            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<controller>/5
        /// <summary>
        /// Exclui um livro previamente existente na base de dados.
        /// </summary>
        /// <param name="model">Modelo de Livro</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Autor autor = _context.Autores.Find(id);
                _context.Autores.Remove(autor);
                return StatusCode(200);

            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
