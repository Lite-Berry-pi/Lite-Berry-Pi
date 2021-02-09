using Lite_Berry_Pi.Models.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lite_Berry_Pi.Models
{
    public class UserDesign
    {
       public int UserId { get; set; }
        
        public int DesignId { get; set; }

        //navigation aids

        public User User { get; set; }

        public List<DesignDto> Designs { get; set; }
    }
}
