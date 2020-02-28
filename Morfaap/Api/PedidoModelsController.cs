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
    public class PedidoModelsController : ControllerBase
    {
        private readonly DataContext _context;

        public PedidoModelsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PedidoModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoModel>>> GetPedido()
        {
            return await _context.Pedido.ToListAsync();
        }

        // GET: api/PedidoModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoModel>> GetPedidoModel(int id)
        {
            var pedidoModel = await _context.Pedido.FindAsync(id);

            if (pedidoModel == null)
            {
                return NotFound();
            }

            return pedidoModel;
        }


        [HttpGet("ultimo")]
        public async Task<ActionResult<PedidoModel>> Ultimo()
        {
            var pedidoModel = await _context.Pedido.LastAsync();
            return pedidoModel;
        }

        // PUT: api/PedidoModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedidoModel(int id, PedidoModel pedidoModel)
        {
            if (id != pedidoModel.IdPedido)
            {
                return BadRequest();
            }

            _context.Entry(pedidoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoModelExists(id))
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

        // POST: api/PedidoModels
        [HttpPost]
        public async Task<IActionResult> PostPedidoModel(PedidoModel pedidoModel)
        {
            _context.Pedido.Add(pedidoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedidoModel", new { id = pedidoModel.IdPedido }, pedidoModel);
        }

        // DELETE: api/PedidoModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PedidoModel>> DeletePedidoModel(int id)
        {
            var pedidoModel = await _context.Pedido.FindAsync(id);
            if (pedidoModel == null)
            {
                return NotFound();
            }

            _context.Pedido.Remove(pedidoModel);
            await _context.SaveChangesAsync();

            return pedidoModel;
        }

        private bool PedidoModelExists(int id)
        {
            return _context.Pedido.Any(e => e.IdPedido == id);
        }
    }
}
