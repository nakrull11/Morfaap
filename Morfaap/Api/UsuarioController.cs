using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Morfaap.Models;

namespace Morfaap.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly DataContext contexto;
        private readonly IConfiguration config;

        public UsuarioController(DataContext contexto, IConfiguration config)
        {
            this.contexto = contexto;
            this.config = config;
        }
        // GET: api/Usuario
        [HttpGet]
        public async Task<IActionResult> Get()  
        {
            try
            {
                //var usuario = User.Identity.Name;
                return Ok(contexto.Usuario.SingleOrDefault(x => x.Email == "gusguz1994@gmail.com"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/Usuario/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(contexto.Usuario.SingleOrDefault(x => x.IdUsuario == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // POST: api/Usuario
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
