using Lite_Berry_Pi.Models;
using Lite_Berry_Pi.Models.Api;
using Lite_Berry_Pi.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
    #region //standardCrud
    [AllowAnonymous]
    // GET: api/Designs/getall
    [HttpGet("/getall")]

    public async Task<ActionResult<IEnumerable<Design>>> GetDesigns()
    {
      return Ok(await _design.GetAllDesigns());
    }
    [AllowAnonymous]
    // GET: api/Designs/id/5
    [HttpGet("/id/{id}")]
    public async Task<ActionResult<DesignDto>> GetDesignById(int id)
    {
      var design = await _design.GetDesignById(id);

      if (design == null)
      {
        return NotFound();
      }
      return design;
    }
    [AllowAnonymous]
    //GET: api/Designs/title
    [HttpGet("/title/{title}")]
    public async Task<ActionResult<DesignDto>> GetDesignByTitle(string title)
    {
      var design = await _design.GetDesignByTitle(title);

      if (design == null) return NotFound();

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
    //[Authorize(Roles = "Administrator")]
    [AllowAnonymous]
    // DELETE: api/Designs/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Design>> DeleteDesign(int id)
    {
      await _design.DeleteDesign(id);
      return NoContent();
    }
#endregion 
    [AllowAnonymous]
    // GET: api/Designs/send_design_id/3
    [HttpGet("send_design_id/{id}")]
    //Socket Routes
    public async Task<ActionResult<Design>> GetAndSendDesignById(int id)
    {
      bool didSend = await _design.SendDesignByIdSocket(id);
      return Ok(didSend);
    }
    [AllowAnonymous]
    // GET: api/Designs/send_design_id/squareBurst
    [HttpGet("send_design/{title}")]
    public async Task<ActionResult<Design>> GetAndSendDesignByTitle(string title)
    {
      bool didSend = await _design.SendDesignByTitleSocket(title);
      return Ok(didSend);
    }
    [AllowAnonymous]
    //GET: api/Designs/TestConnection
    
    [HttpGet("testconnection")]    
    public async Task<ActionResult> TestConnection()
    {
      try
      {
        Debug.WriteLine($"Testing Connection");
        await _design.TestConnection();
        Debug.WriteLine("Test Connection complete");
      return Ok("Connection Tested Complete");
      }
      catch (Exception err)
      {
        return BadRequest(err);
      }
    }
    [AllowAnonymous]
    //GET: api/Designs/stdpattern/squareburst/animation
    [HttpGet("stddesign/{name}/{type}")]
    public async Task<IActionResult> StandardDesign(string name, string type)
    {
      try
      {
        string key = $"{type}:{name}";
        Debug.WriteLine($"Key: {key}");
        await _design.DisplayStandardDesign(key);        
        return Ok(key);
      }
      catch(Exception err)
      {
        return BadRequest(err);
      }
    }
  }
}
