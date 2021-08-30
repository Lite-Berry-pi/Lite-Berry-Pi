﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lite_Berry_Pi.Models.Api
{
    public class ApplicationUserDto
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Username { get; set; }

        public string Token { get; set; }

       

        
    }
}
