using ApiAuditoria.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ApiAuditoria.Controllers
{
    [Produces("application/json")]
    [Route("api/Log")]
    public class LogController : Controller
    {
        private readonly AuditoriaContext _auditoriaContext;

        public LogController(AuditoriaContext auditoriaContext)
        {
            _auditoriaContext = auditoriaContext;
        }


        // GET: api/Log
        /// <summary>
        /// Retorna um conjunto de logs.
        /// </summary>
        /// <param name="startDate">Data início das Logs</param>
        /// <param name="endDate">Data fim das logs</param>
        /// <param name="skip">Número de registros a serem  ignorados. Se não informado, 0.</param>
        /// <param name="take">Número de registros retornados na lista. Se não informado, 20, máximo permitido 100.</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult Get(DateTime startDate, DateTime endDate, int skip = 0, int take = 20)
        {
            if ((take - skip) > 100)
                take = 100 + skip;
            try
            {
                var users = _auditoriaContext.Logs.Where(u => u.DataAcesso >= startDate && u.DataAcesso <= endDate).OrderBy(u=>u.DataAcesso).Skip(skip).Take(take).ToList();
                if (users == null)
                    return new EmptyResult();
                else
                {
                    return Ok(users);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        // POST: api/Log
        /// <summary>
        /// Cria um log na base.
        /// </summary>
        /// <param name="model"> Objeto do tipo usuário.</param>
        /// <returns></returns>
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [HttpPost]
        public IActionResult Post([FromBody]Log model)
        {
            try
            {
                _auditoriaContext.Logs.Add(model);
                _auditoriaContext.SaveChanges();
                return StatusCode(201, "Log criado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
    }
}
