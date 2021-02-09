using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lite_Berry_Pi.Models.Interfaces
{
    public interface IActivityLog
    {
        Task<ActivityLog> Create(ActivityLog activityLog);
        Task<ActivityLog> GetActivityLog(int id);

        Task<List<ActivityLog>> GetListOfActivities();

        Task<ActivityLog> UpdateActivityLog(int id, ActivityLog activityLog);

        Task AttachActivityLogToUser(int id, int userId);

        Task DeleteActivity(int id);
    }
}
