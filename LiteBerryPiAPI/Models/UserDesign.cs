namespace Lite_Berry_Pi.Models
{
  public class UserDesign
  {
    public int UserId { get; set; }

    public int DesignId { get; set; }

    //navigation aids

    public User User { get; set; }

    public Design Designs { get; set; }
  }
}
