using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lite_Berry_Pi.Models.Api
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ActivityLog> ActivityLogs { get; set; }

        public List<DesignDto> UserDesigns { get; set; }
    }
}
