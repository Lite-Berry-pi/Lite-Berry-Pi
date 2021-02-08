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
    public class ActivityLogsController : ControllerBase
    {
        private readonly LiteBerryDbContext _context;

        public ActivityLogsController(LiteBerryDbContext context)
        {
            _context = context;
        }

        // GET: api/ActivityLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityLog>>> GetActivityLog()
        {
            return await _context.ActivityLog.ToListAsync();
        }

        // GET: api/ActivityLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityLog>> GetActivityLog(int id)
        {
            var activityLog = await _context.ActivityLog.FindAsync(id);

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

            _context.Entry(activityLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityLogExists(id))
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

        // POST: api/ActivityLogs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ActivityLog>> PostActivityLog(ActivityLog activityLog)
        {
            _context.ActivityLog.Add(activityLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivityLog", new { id = activityLog.Id }, activityLog);
        }

        // DELETE: api/ActivityLogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ActivityLog>> DeleteActivityLog(int id)
        {
            var activityLog = await _context.ActivityLog.FindAsync(id);
            if (activityLog == null)
            {
                return NotFound();
            }

            _context.ActivityLog.Remove(activityLog);
            await _context.SaveChangesAsync();

            return activityLog;
        }

        private bool ActivityLogExists(int id)
        {
            return _context.ActivityLog.Any(e => e.Id == id);
        }
    }
}
