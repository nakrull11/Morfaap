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
    public class ComentarioModelsController : ControllerBase
    {
        private readonly DataContext _context;

        public ComentarioModelsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ComentarioModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComentarioModel>>> GetComentario()
        {
            return await _context.Comentario.ToListAsync();
        }

        // GET: api/ComentarioModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComentarioModel>> GetComentarioModel(int id)
        {
            var comentarioModel = await _context.Comentario.FindAsync(id);

            if (comentarioModel == null)
            {
                return NotFound();
            }

            return comentarioModel;
        }

        // PUT: api/ComentarioModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComentarioModel(int id, ComentarioModel comentarioModel)
        {
            if (id != comentarioModel.IdUsuario)
            {
                return BadRequest();
            }

            _context.Entry(comentarioModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComentarioModelExists(id))
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

        // POST: api/ComentarioModels
        [HttpPost]
        public async Task<ActionResult<ComentarioModel>> PostComentarioModel(ComentarioModel comentarioModel)
        {
            _context.Comentario.Add(comentarioModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ComentarioModelExists(comentarioModel.IdUsuario))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetComentarioModel", new { id = comentarioModel.IdUsuario }, comentarioModel);
        }

        // DELETE: api/ComentarioModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ComentarioModel>> DeleteComentarioModel(int id)
        {
            var comentarioModel = await _context.Comentario.FindAsync(id);
            if (comentarioModel == null)
            {
                return NotFound();
            }

            _context.Comentario.Remove(comentarioModel);
            await _context.SaveChangesAsync();

            return comentarioModel;
        }

        private bool ComentarioModelExists(int id)
        {
            return _context.Comentario.Any(e => e.IdUsuario == id);
        }
    }
}
