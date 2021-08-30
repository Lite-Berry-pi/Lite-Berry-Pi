using Lite_Berry_Pi.Models;
using Lite_Berry_Pi.Models.Api;
using Lite_Berry_Pi.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Lite_Berry_Pi.Controllers
{
  [Authorize]

  [Route("api/[controller]")]
  [ApiController]
  public class DesignsController : ControllerBase
  {
    private readonly IDesign _design;

    public DesignsController(IDesign design)
    {
      _design = design;
    }
    [AllowAnonymous]
    // GET: api/Designs
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Design>>> GetDesigns()
    {
      return Ok(await _design.GetAllDesigns());
    }
    [AllowAnonymous]
    // GET: api/Designs/5
    [HttpGet("{id}")]
    public async Task<ActionResult<DesignDto>> GetDesign(int id)
    {
      var design = await _design.GetDesign(id);

      if (design == null)
      {
        return NotFound();
      }
      return design;
    }
    //[Authorize(Roles = "Administrator")]
    [AllowAnonymous]
    // PUT: api/Designs/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDesign(int id, DesignDto incomingData)
    {
      if (id != incomingData.Id)
      {
        return BadRequest();
      }

      var updatedDesign = await _design.UpdateDesign(id, incomingData);
      return Ok(updatedDesign);
    }

    [AllowAnonymous]
    // POST: api/Designs
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public async Task<ActionResult<Design>> PostDesign(DesignDto incomingData)
    {
      await _design.CreateDesign(incomingData);
      return CreatedAtAction("GetDesign", new { id = incomingData.Id }, incomingData);
    }
    [Authorize(Roles = "Administrator")]
    // DELETE: api/Designs/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Design>> DeleteDesign(int id)
    {
      await _design.DeleteDesign(id);
      return NoContent();
    }

    [AllowAnonymous]
    // GET: api/Designs/GetDesigns/3
    [HttpGet("getdesign/{id}")]
    public async Task<ActionResult<Design>> GetDesignToSend(int id)
    {
      await _design.GetDesignToSend(id);
      return Ok();
    }
    [AllowAnonymous]
    //GET: api/Designs/TestConnection
    [HttpGet("testconnection")]
    public async Task<ActionResult> TestConnection()
    {
      Debug.WriteLine($"Testing Connection");
      await _design.TestConnection();
      Debug.WriteLine("Test Connection complete");
      return NoContent();
    }
  }
}
