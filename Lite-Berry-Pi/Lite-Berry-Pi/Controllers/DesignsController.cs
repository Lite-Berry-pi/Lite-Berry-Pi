using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lite_Berry_Pi.Data;
using Lite_Berry_Pi.Models;
using Lite_Berry_Pi.Models.Interfaces;
using Lite_Berry_Pi.Models.Api;

namespace Lite_Berry_Pi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignsController : ControllerBase
    {
        private readonly IDesign _design;

        public DesignsController(IDesign design)
        {
            _design = design;
        }

        // GET: api/Designs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Design>>> GetDesigns()
        {
            return Ok(await _design.GetAllDesigns());
        }

        // GET: api/Designs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DesignDto>> GetDesign(int id)
        {
            var design = await _design.GetDesign(id);

            if(design == null)
            {
                return NotFound();
            }
            return design;
        }

        // PUT: api/Designs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesign(int id, DesignDto incomingData)
        {
            if(id != incomingData.Id)
            {
                return BadRequest();
            }

            var updatedDesign = await _design.UpdateDesign(id, incomingData);
            return Ok(updatedDesign);
        }

        // POST: api/Designs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Design>> PostDesign(DesignDto incomingData)
        {
            await _design.CreateDesign(incomingData);
            return CreatedAtAction("GetDesign", new { id = incomingData.Id  }, incomingData);
        }

        // DELETE: api/Designs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Design>> DeleteDesign(int id)
        {
            await _design.DeleteDesign(id);
            return NoContent();
        }

        // GET: api/Designs/GetDesigns/3
        [HttpGet("getdesign/{id}")]
        public async Task<ActionResult<Design>> GetDesignToSend(int id)
        {
            await _design.GetDesignToSend(id);
            return Ok();
        }
    }
}
