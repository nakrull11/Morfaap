using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Morfaap.Models;

namespace Morfaap.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioModelsController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuarioModelsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/UsuarioModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioModel>>> GetUsuario()
        {
            return await _context.Usuario.ToListAsync();
        }

        // GET: api/UsuarioModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> GetUsuarioModel(int id)
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
        public async Task<IActionResult> PutUsuarioModel(int id, UsuarioModel usuarioModel)
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
        public async Task<ActionResult<UsuarioModel>> PostUsuarioModel(UsuarioModel usuarioModel)
        {
            _context.Usuario.Add(usuarioModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarioModel", new { id = usuarioModel.IdUsuario }, usuarioModel);
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
