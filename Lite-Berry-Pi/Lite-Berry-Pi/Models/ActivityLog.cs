using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lite_Berry_Pi.Models
{
    public class ActivityLog
    {
        public int Id { get; set; }

        public DateTime LoginTime { get; set; }
         
        public DateTime SendTime { get; set; }

        //Navigation Properties:
        public List<Design> Designs { get; set; }

        public User User { get; set; }

    }
}
