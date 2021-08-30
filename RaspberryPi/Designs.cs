using System;
using System.Collections.Generic;
using System.Text;

namespace RaspberryPi
{
  public class Designs
  {
    public Dictionary<string, List<LED>> Pattern { get; set; }
    private Lights LightMatrix { get; set; }
    public Designs()
    {
      Pattern = new Dictionary<string, List<LED>>();
      LightMatrix = new Lights();
      Console.WriteLine($"Pattern: {Pattern.Keys}");
      SeedPatterns();
      Console.WriteLine("PostPattern");
    }
      public void SeedPatterns()
      {
      Pattern.Add("J", new List<LED>
      {
      LightMatrix.L3,
        LightMatrix.L3,
        LightMatrix.L8,
        LightMatrix.L13,
        LightMatrix.L16,
        LightMatrix.L18,
        LightMatrix.L21,
        LightMatrix.L22,
        LightMatrix.L23
      });
      Pattern.Add("M", new List<LED>
        {
          LightMatrix.L1,
            LightMatrix.L5,
            LightMatrix.L6,
            LightMatrix.L7,
            LightMatrix.L9,
            LightMatrix.L10,
            LightMatrix.L11,
            LightMatrix.L13,
            LightMatrix.L15,
            LightMatrix.L16,
            LightMatrix.L20,
            LightMatrix.L21,
            LightMatrix.L25
        });
      Pattern.Add("DIAMOND", new List<LED>
        {
            LightMatrix.L3,
            LightMatrix.L7,
            LightMatrix.L9,
            LightMatrix.L11,
            LightMatrix.L15,
            LightMatrix.L17,
            LightMatrix.L19,
            LightMatrix.L23
      });
    }
  }
}
