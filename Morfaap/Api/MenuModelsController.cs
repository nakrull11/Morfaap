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
    public class MenuModelsController : ControllerBase
    {
        private readonly DataContext _context;

        public MenuModelsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/MenuModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuModel>>> GetMenu()
        {
            return await _context.Menu.ToListAsync();
        }

        // GET: api/MenuModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MenuModel>> GetMenuModel(int id)
        {
            var menuModel = await _context.Menu.FindAsync(id);

            if (menuModel == null)
            {
                return NotFound();
            }

            return menuModel;
        }

        // PUT: api/MenuModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuModel(int id, MenuModel menuModel)
        {
            if (id != menuModel.IdMenu)
            {
                return BadRequest();
            }

            _context.Entry(menuModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuModelExists(id))
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

        // POST: api/MenuModels
        [HttpPost]
        public async Task<ActionResult<MenuModel>> PostMenuModel(MenuModel menuModel)
        {
            _context.Menu.Add(menuModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenuModel", new { id = menuModel.IdMenu }, menuModel);
        }

        // DELETE: api/MenuModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MenuModel>> DeleteMenuModel(int id)
        {
            var menuModel = await _context.Menu.FindAsync(id);
            if (menuModel == null)
            {
                return NotFound();
            }

            _context.Menu.Remove(menuModel);
            await _context.SaveChangesAsync();

            return menuModel;
        }

        private bool MenuModelExists(int id)
        {
            return _context.Menu.Any(e => e.IdMenu == id);
        }
    }
}
