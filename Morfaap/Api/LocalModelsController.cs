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
    public class LocalModelsController : ControllerBase
    {
        private readonly DataContext _context;

        public LocalModelsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/LocalModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocalModel>>> GetLocal()
        {
            return await _context.Local.ToListAsync();
        }

        // GET: api/LocalModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocalModel>> GetLocalModel(int id)
        {
            var localModel = await _context.Local.FindAsync(id);

            if (localModel == null)
            {
                return NotFound();
            }

            return localModel;
        }

        // PUT: api/LocalModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocalModel(int id, LocalModel localModel)
        {
            if (id != localModel.IdLocal)
            {
                return BadRequest();
            }

            _context.Entry(localModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalModelExists(id))
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

        // POST: api/LocalModels
        [HttpPost]
        public async Task<ActionResult<LocalModel>> PostLocalModel(LocalModel localModel)
        {
            _context.Local.Add(localModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocalModel", new { id = localModel.IdLocal }, localModel);
        }

        // DELETE: api/LocalModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LocalModel>> DeleteLocalModel(int id)
        {
            var localModel = await _context.Local.FindAsync(id);
            if (localModel == null)
            {
                return NotFound();
            }

            _context.Local.Remove(localModel);
            await _context.SaveChangesAsync();

            return localModel;
        }

        private bool LocalModelExists(int id)
        {
            return _context.Local.Any(e => e.IdLocal == id);
        }
    }
}
