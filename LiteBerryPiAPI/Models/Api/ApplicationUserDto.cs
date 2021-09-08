using System.ComponentModel.DataAnnotations;

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
