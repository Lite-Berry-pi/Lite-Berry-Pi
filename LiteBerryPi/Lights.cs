using System.Collections.Generic;

namespace RaspberryPi
{
  public class Lights
  {
    public List<LED> AllLights { get; set; }
    public LED L1 { get; set; }
    public LED L2 { get; set; }
    public LED L3 { get; set; }
    public LED L4 { get; set; }
    public LED L5 { get; set; }
    public LED L6 { get; set; }
    public LED L7 { get; set; }
    public LED L8 { get; set; }
    public LED L9 { get; set; }
    public LED L10 { get; set; }
    public LED L11 { get; set; }
    public LED L12 { get; set; }
    public LED L13 { get; set; }
    public LED L14 { get; set; }
    public LED L15 { get; set; }
    public LED L16 { get; set; }
    public LED L17 { get; set; }
    public LED L18 { get; set; }
    public LED L19 { get; set; }
    public LED L20 { get; set; }
    public LED L21 { get; set; }
    public LED L22 { get; set; }
    public LED L23 { get; set; }
    public LED L24 { get; set; }
    public LED L25 { get; set; }
    public Lights()
    {
      L1 = new LED() { Column = 7, Row = 5, ID = 1 };
      L2 = new LED() { Column = 12, Row = 5, ID = 2 };
      L3 = new LED() { Column = 16, Row = 5, ID = 3 };
      L4 = new LED() { Column = 20, Row = 5, ID = 4 };
      L5 = new LED() { Column = 21, Row = 5, ID = 5 };
      L6 = new LED() { Column = 7, Row = 6, ID = 6 };
      L7 = new LED() { Column = 12, Row = 6, ID = 7 };
      L8 = new LED() { Column = 16, Row = 6, ID = 8 };
      L9 = new LED() { Column = 20, Row = 6, ID = 9 };
      L10 = new LED() { Column = 21, Row = 6, ID = 10 };
      L11 = new LED() { Column = 7, Row = 13, ID = 11 };
      L12 = new LED() { Column = 12, Row = 13, ID = 12 };
      L13 = new LED() { Column = 16, Row = 13, ID = 13 };
      L14 = new LED() { Column = 20, Row = 13, ID = 14 };
      L15 = new LED() { Column = 21, Row = 13, ID = 15 };
      L16 = new LED() { Column = 7, Row = 19, ID = 16 };
      L17 = new LED() { Column = 12, Row = 19, ID = 17 };
      L18 = new LED() { Column = 16, Row = 19, ID = 18 };
      L19 = new LED() { Column = 20, Row = 19, ID = 19 };
      L20 = new LED() { Column = 21, Row = 19, ID = 20 };
      L21 = new LED() { Column = 7, Row = 26, ID = 21 };
      L22 = new LED() { Column = 12, Row = 26, ID = 22 };
      L23 = new LED() { Column = 16, Row = 26, ID = 23 };
      L24 = new LED() { Column = 20, Row = 26, ID = 24 };
      L25 = new LED() { Column = 21, Row = 26, ID = 25 };

      AllLights = new List<LED>
      {
        L1, L2, L3, L4, L5, L6, L7, L8, L9, L10, L11, L12, L13, L14, L15, L16, L17, L18, L19,
        L20, L21, L22, L23, L24, L25
      };
    }
    /// <summary>
    /// Convert a String of data to a LED List object for Display
    /// </summary>
    /// <param name="inString"></param>
    /// <returns></returns>
    public List<LED> CreateLightPattern(string inString)
    {
      if (AllLights.Count != inString.Length)
      {
        throw new System.Exception("Input string does no match the elements in Light List");
      }
      List<LED> newList = new List<LED>();

      for (int i = 0; i < inString.Length; i++)
      {
        if (inString[i] == '1')
        {
          newList.Add(AllLights[i]);
        }
      }
      foreach (LED led in newList) { System.Console.WriteLine(led.ID); }
      return newList;
    }
  }
}
