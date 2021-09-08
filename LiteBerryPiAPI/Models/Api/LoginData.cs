using System.ComponentModel.DataAnnotations;


namespace Lite_Berry_Pi.Models.Api
{
  public class LoginData
  {
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

  }
}
