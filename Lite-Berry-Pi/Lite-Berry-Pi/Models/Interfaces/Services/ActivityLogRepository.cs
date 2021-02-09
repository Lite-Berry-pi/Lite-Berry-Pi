using Lite_Berry_Pi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lite_Berry_Pi.Models;

namespace Lite_Berry_Pi.Models.Interfaces.Services
{
    public class ActivityLogRepository : IActivityLog
    {
        private LiteBerryDbContext _context;

        public ActivityLogRepository(LiteBerryDbContext context)
        {
            _context = context;
        }
        // Check to make sure we don't need to pass in id
        public async Task AttachActivityLogToUser(int id, int userId)
        {
            _context.Entry(userId).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
           
        }

        public async Task<ActivityLog> Create(ActivityLog activityLog)
        {
            _context.Entry(activityLog).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();

            return activityLog;
        }

        public async Task DeleteActivity(int id)
        {
            ActivityLog activityLog = await _context.ActivityLog.FindAsync(id);
            _context.Entry(activityLog).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<ActivityLog> GetActivityLog(int id)
        {
            return await _context.ActivityLog            
                  .FindAsync(id);
        }

        public async Task<List<ActivityLog>> GetListOfActivities()
        {
            var activities = await _context.ActivityLog.ToListAsync();
            return activities;
        }

        public async Task<ActivityLog> UpdateActivityLog(int id, ActivityLog activityLog)
        {
            _context.Entry(activityLog).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return activityLog;
        }

        
    }
}
