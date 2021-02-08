using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lite_Berry_Pi.Models
{
    public class Design
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public DateTime TimeStamp { get; set; }

        public string DesignCoords { get; set; }


        //Navigation Properties:
        public UserDesign UserDesign { get; set; }
    }
}
