using System.ComponentModel.DataAnnotations;

namespace RaspberryPi
{
  public class LED
  {
    public int ID{get; set;}
    [Required]
    public int Column { get; set; }

    [Required]
    public int Row { get; set; }


  }
}
