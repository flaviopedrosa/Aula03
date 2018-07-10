using System;
using System.Linq;
using ApiAutenticacao.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiAutenticacao.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private AutenticaoContext _autenticaoContext;
        public UserController(AutenticaoContext autenticaoContext)
        {
            this._autenticaoContext = autenticaoContext;
        }

        // GET: api/User
        /// <summary>
        /// Recupera  lista de usuários
        /// </summary>
        /// <param name="userName">Parte do nome do usuário.</param>
        /// <param name="skip">Número de registros a serem  ignorados. Se não informado, 0.</param>
        /// <param name="take">Número de registros retornados na lista. Se não informado, 20, máximo permitido 100.</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public IActionResult Get(string  userName, int skip = 0, int take=20)
        {
            if ((take - skip) > 100)
                take = 100 + skip;
            try
            {
                var users = _autenticaoContext.Users.Where(u => u.Name.Contains(userName) || userName == null).Skip(skip).Take(take).ToList();
                if (users == null)
                    return new EmptyResult();
                else
                {
                    return Ok(users);
                }
            }
            catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/User/5
        /// <summary>
        /// Recupera o usuário baseado em uma chave.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(string id)
        {
            try
            {
                var user = _autenticaoContext.Users.Find(id);
                if (user == null)
                    return new EmptyResult();
                else
                {
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/User
        /// <summary>
        /// Cria um novo usuário na base.
        /// </summary>
        /// <param name="model"> Objeto do tipo usuário.</param>
        /// <returns></returns>
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [HttpPost]
        public IActionResult Post([FromBody]User model)
        {
            try
            {
                string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                model.UserID = Guid.NewGuid().ToString();
                model.AccessKey = token;
                _autenticaoContext.Users.Add(model);
                _autenticaoContext.SaveChanges();
                return StatusCode(201, "Usuário criado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/User/5
        /// <summary>
        /// Atualiza um usuário existente na base.
        /// </summary>
        /// <param name="id">Código do usuário</param>
        /// <param name="model"> Objeto do tipo usuário.</param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]User model)
        {
            try
            {
                var userInDb = _autenticaoContext.Users.Find(id);
                if(userInDb == null)
                {
                    return StatusCode(500, "Usuário não existe na base de dados.");
                }
                else
                {
                    _autenticaoContext.Entry(userInDb).CurrentValues.SetValues(model);
                    _autenticaoContext.SaveChanges();
                    return StatusCode(200, "Usuário atualizado com sucesso.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// Exclui um objeto da base.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var userInDb = _autenticaoContext.Users.Find(id);
                if (userInDb == null)
                {
                    return StatusCode(500, "Usuário não existe na base de dados.");
                }
                else
                {
                    _autenticaoContext.Remove(userInDb);
                    return StatusCode(200, "Usuário excluído com sucesso.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
