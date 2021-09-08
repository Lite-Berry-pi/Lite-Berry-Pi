﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lite_Berry_Pi.Models.Api
{
  public class UserDto
  {
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    public List<ActivityLog> ActivityLogs { get; set; }

    public List<DesignDto> UserDesigns { get; set; }
  }
}
