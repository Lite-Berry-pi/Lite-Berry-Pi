using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lite_Berry_Pi.Models.Api
{
    public class RegisterUser
    {

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Roles { get; set; }
        
    }
}
