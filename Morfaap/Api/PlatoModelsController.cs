using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Morfaap.Models;

namespace Morfaap.Api
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class PlatoModelsController : ControllerBase
    {

        private readonly DataContext _context;

        public PlatoModelsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PlatoModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatoModel>>> GetPlato()
        {
            var platoConMenu = _context.Plato.
                Include(m => m.Menu).
                ThenInclude(l => l.Local).
                ThenInclude(p => p.Propietario)
                .ToListAsync();
            return await platoConMenu;
        }

        // GET: api/PlatoModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPlatoModel(int id)
        {
            var platoModel =  _context.Plato.
                Include(m => m.Menu).
                ThenInclude(l => l.Local).
                ThenInclude(p => p.Propietario).
                Where(x => x.IdPlato == id);

            if (platoModel == null)
            {
                return NotFound();
            }

            return Ok(platoModel);
        }

        // PUT: api/PlatoModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlatoModel(int id, PlatoModel platoModel)
        {
            if (id != platoModel.IdPlato)
            {
                return BadRequest();
            }

            _context.Entry(platoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatoModelExists(id))
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

        // POST: api/PlatoModels
        [HttpPost]
        public async Task<ActionResult<PlatoModel>> PostPlatoModel(PlatoModel platoModel)
        {
            _context.Plato.Add(platoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlatoModel", new { id = platoModel.IdPlato }, platoModel);
        }

        // DELETE: api/PlatoModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlatoModel>> DeletePlatoModel(int id)
        {
            var platoModel = await _context.Plato.FindAsync(id);
            if (platoModel == null)
            {
                return NotFound();
            }

            _context.Plato.Remove(platoModel);
            await _context.SaveChangesAsync();

            return platoModel;
        }

        private bool PlatoModelExists(int id)
        {
            return _context.Plato.Any(e => e.IdPlato == id);
        }
    }
}
