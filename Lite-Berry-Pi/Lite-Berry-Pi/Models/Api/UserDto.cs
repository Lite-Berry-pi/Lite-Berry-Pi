using System.Collections.Generic;

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
