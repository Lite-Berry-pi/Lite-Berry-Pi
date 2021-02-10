using Lite_Berry_Pi.Models;
using Lite_Berry_Pi.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lite_Berry_Pi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ActivityLogsController : ControllerBase
  {
    private readonly IActivityLog _activityLog;

    public ActivityLogsController(IActivityLog activityLog)
    {
      _activityLog = activityLog;
    }



    // GET: api/ActivityLogs
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ActivityLog>>> GetActivityLog()
    {
      return await _activityLog.GetListOfActivities();
    }

    // GET: api/ActivityLogs/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ActivityLog>> GetActivityLog(int id)
    {
      var activityLog = await _activityLog.GetActivityLog(id);

      if (activityLog == null)
      {
        return NotFound();
      }

      return activityLog;
    }

    // PUT: api/ActivityLogs/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{id}")]
    public async Task<IActionResult> PutActivityLog(int id, ActivityLog activityLog)
    {
      if (id != activityLog.Id)
      {
        return BadRequest();
      }
      var updatedActivityLog = await _activityLog.UpdateActivityLog(id, activityLog);
      return Ok(updatedActivityLog);
    }

    // POST: api/ActivityLogs
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public async Task<ActionResult<ActivityLog>> PostActivityLog(ActivityLog activityLog)
    {

      await _activityLog.Create(activityLog);

      return CreatedAtAction("GetActivityLog", new { id = activityLog.Id }, activityLog);
    }

    // DELETE: api/ActivityLogs/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<ActivityLog>> DeleteActivityLog(int id)
    {
      await _activityLog.DeleteActivity(id);

      return NoContent();
    }


  }
}
