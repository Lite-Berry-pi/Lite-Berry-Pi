using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lite_Berry_Pi.Models
{
    public class Design
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }

        public DateTime TimeStamp { get; set; }

        [Required]
        public string DesignCoords { get; set; }


        //Navigation Properties:
        public UserDesign UserDesign { get; set; }
    }
}
