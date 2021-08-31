using System;
using System.ComponentModel.DataAnnotations;

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
