using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Morfaap.Models;

namespace Morfaap.Api
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class UsuarioModelsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration config;

        public UsuarioModelsController(DataContext context, IConfiguration config)
        {
            _context = context;
            this.config = config;
        }

        // GET: api/UsuarioModels
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                var usuario = User.Identity.Name;
                return Ok(_context.Usuario.SingleOrDefault(x => x.Email == usuario));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/UsuarioModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> Get(int id)
        {
            var usuarioModel = await _context.Usuario.FindAsync(id);

            if (usuarioModel == null)
            {
                return NotFound();
            }

            return usuarioModel;
        }

        // PUT: api/UsuarioModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,UsuarioModel usuarioModel)
        {
            if (id != usuarioModel.IdUsuario)
            {
                return BadRequest();
            }

            _context.Entry(usuarioModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UsuarioModels
        [HttpPost]
        public async Task<IActionResult> Post(UsuarioModel usuarioModel)
        {
            _context.Usuario.Add(usuarioModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioModel", new { id = usuarioModel.IdUsuario }, usuarioModel);
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginView loginView)
        {
            try
            {

                //string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                  string password= loginView.Password;
                  /*  salt: System.Text.Encoding.ASCII.GetBytes(config["Salt"]),
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 1000,
                    numBytesRequested: 256 / 8));*/
                var p = _context.Usuario.FirstOrDefault(x => x.Email == loginView.Email);
                if (p == null || p.Password != password)
                {
                    return BadRequest("Nombre de usuario o clave incorrecta");
                }
                else
                {
                    var key = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(config["TokenAuthentication:SecretKey"]));
                    var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, p.Email),
                        new Claim("FullName", p.Email),
                        new Claim(ClaimTypes.Role, "Usuario"),
                    };

                    var token = new JwtSecurityToken(
                        issuer: config["TokenAuthentication:Issuer"],
                        audience: config["TokenAuthentication:Audience"],
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(60),
                        signingCredentials: credenciales
                    );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE: api/UsuarioModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> DeleteUsuarioModel(int id)
        {
            var usuarioModel = await _context.Usuario.FindAsync(id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuarioModel);
            await _context.SaveChangesAsync();

            return usuarioModel;
        }

        private bool UsuarioModelExists(int id)
        {
            return _context.Usuario.Any(e => e.IdUsuario == id);
        }
    }
}
