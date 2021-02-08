using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lite_Berry_Pi.Data;
using Lite_Berry_Pi.Models;

namespace Lite_Berry_Pi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignsController : ControllerBase
    {
        private readonly LiteBerryDbContext _context;

        public DesignsController(LiteBerryDbContext context)
        {
            _context = context;
        }

        // GET: api/Designs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Design>>> GetDesign()
        {
            return await _context.Design.ToListAsync();
        }

        // GET: api/Designs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Design>> GetDesign(int id)
        {
            var design = await _context.Design.FindAsync(id);

            if (design == null)
            {
                return NotFound();
            }

            return design;
        }

        // PUT: api/Designs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesign(int id, Design design)
        {
            if (id != design.Id)
            {
                return BadRequest();
            }

            _context.Entry(design).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesignExists(id))
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

        // POST: api/Designs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Design>> PostDesign(Design design)
        {
            _context.Design.Add(design);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDesign", new { id = design.Id }, design);
        }

        // DELETE: api/Designs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Design>> DeleteDesign(int id)
        {
            var design = await _context.Design.FindAsync(id);
            if (design == null)
            {
                return NotFound();
            }

            _context.Design.Remove(design);
            await _context.SaveChangesAsync();

            return design;
        }

        private bool DesignExists(int id)
        {
            return _context.Design.Any(e => e.Id == id);
        }
    }
}
