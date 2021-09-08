using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lite_Berry_Pi.Models
{
  public class User
  {
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    //Navigation Properties:

    public List<UserDesign> UserDesigns { get; set; }

    public List<ActivityLog> ActivityLogs { get; set; }

  }
}
