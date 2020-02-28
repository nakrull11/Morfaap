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
    public class DetalleModelsController : ControllerBase
    {
        private readonly DataContext _context;

        public DetalleModelsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/DetalleModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleModel>>> GetDetalle()
        {
            return await _context.Detalle.ToListAsync();
        }

        // GET: api/DetalleModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleModel>> GetDetalleModel(int id)
        {
            var detalleModel = await _context.Detalle.FindAsync(id);

            if (detalleModel == null)
            {
                return NotFound();
            }

            return detalleModel;
        }

        // PUT: api/DetalleModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleModel(int id, DetalleModel detalleModel)
        {
            if (id != detalleModel.IdDetalle)
            {
                return BadRequest();
            }

            _context.Entry(detalleModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleModelExists(id))
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

        // POST: api/DetalleModels
        [HttpPost]
        public async Task<ActionResult<DetalleModel>> PostDetalleModel(DetalleModel detalleModel)
        {
            _context.Detalle.Add(detalleModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleModel", new { id = detalleModel.IdDetalle }, detalleModel);
        }

        // DELETE: api/DetalleModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DetalleModel>> DeleteDetalleModel(int id)
        {
            var detalleModel = await _context.Detalle.FindAsync(id);
            if (detalleModel == null)
            {
                return NotFound();
            }

            _context.Detalle.Remove(detalleModel);
            await _context.SaveChangesAsync();

            return detalleModel;
        }

        private bool DetalleModelExists(int id)
        {
            return _context.Detalle.Any(e => e.IdDetalle == id);
        }
    }
}
