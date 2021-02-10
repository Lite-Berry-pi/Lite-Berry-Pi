using RaspberryPi;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RaspberryPiTests
{
  public class RaspberryPiUnitTests
  {
    [Fact]
    public void Generated_List_Matches_Expected()
    {
      Lights lights = new Lights();
      string testString = "0111000100001000010000100";

      List<LED> expectedPattern = new List<LED>()
      {
       lights.L2, lights.L3, lights.L4, lights.L8, lights.L13, lights.L18, lights.L23
      };
      List<LED> generatedPattern = lights.CreateLightPattern(testString);
      
      Assert.True(Enumerable.SequenceEqual(generatedPattern, expectedPattern));      
    }
  }
}
