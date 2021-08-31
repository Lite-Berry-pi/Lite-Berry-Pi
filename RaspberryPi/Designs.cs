using System;
using System.Collections.Generic;

namespace RaspberryPi
{
  public class Designs
  {
    public Dictionary<string, List<LED>> Pattern { get; set; }
    public Dictionary<string, List<List<LED>>> AnimPattern { get; set; }
    private Lights LightMatrix { get; set; }
    public Designs()
    {
      Pattern = new Dictionary<string, List<LED>>();
      AnimPattern = new Dictionary<string, List<List<LED>>>();
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
      //Animations      
      AnimPattern.Add("SQUAREBURST",
        new List<List<LED>>
        {
          new List<LED>() { LightMatrix.L13 },
          new List<LED>() { LightMatrix.L8, LightMatrix.L12, LightMatrix.L14, LightMatrix.L18 },
          new List<LED>() { LightMatrix.L3, LightMatrix.L7, LightMatrix.L9, LightMatrix.L11, LightMatrix.L15, LightMatrix.L17, LightMatrix.L19, LightMatrix.L23 },
          new List<LED>() { LightMatrix.L2, LightMatrix.L4, LightMatrix.L6, LightMatrix.L10, LightMatrix.L16, LightMatrix.L22, LightMatrix.L24, LightMatrix.L20 },
          new List<LED>() { LightMatrix.L1, LightMatrix.L5, LightMatrix.L21, LightMatrix.L25 },
        }
        );
      AnimPattern.Add("FIREWHEEL", new List<List<LED>>
      {
        new List<LED>() {LightMatrix.L3, LightMatrix.L8, LightMatrix.L13, LightMatrix.L18, LightMatrix.L23 },
        new List<LED>() {LightMatrix.L5, LightMatrix.L9, LightMatrix.L13, LightMatrix.L17, LightMatrix.L20 },
        new List<LED>() {LightMatrix.L11, LightMatrix.L12, LightMatrix.L13, LightMatrix.L14, LightMatrix.L15 },
        new List<LED>() {LightMatrix.L1, LightMatrix.L7, LightMatrix.L13, LightMatrix.L14, LightMatrix.L20 },
      });

    }
  }
}
