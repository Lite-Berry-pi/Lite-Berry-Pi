using RaspberryPi;
using System;
using System.Collections.Generic;
using System.Device.Gpio;

namespace LiteBerryPi
{
  class Program
  {
    static void Main(string[] args)
    {
      bool isTest = false;
      // Initial Raspberry Pi GPIO and Light Grid setup
      GpioController controller = new GpioController();
      Lights light = new Lights();
      RaspPi raspi = new RaspPi(light, controller);
      raspi.ClosePins();
      //Pre-Set LED Displays
      List<LED> makeJ = new List<LED>() {
        raspi.Lights.L3,
        raspi.Lights.L3,
        raspi.Lights.L8,
        raspi.Lights.L13,
        raspi.Lights.L16,
        raspi.Lights.L18,
        raspi.Lights.L21,
        raspi.Lights.L22,
        raspi.Lights.L23
      };
      List<LED> makeM = new List<LED>()
        {
          raspi.Lights.L1,
          raspi.Lights.L5,
          raspi.Lights.L6,
          raspi.Lights.L7,
          raspi.Lights.L9,
          raspi.Lights.L10,
          raspi.Lights.L11,
          raspi.Lights.L13,
          raspi.Lights.L15,
          raspi.Lights.L16,
          raspi.Lights.L20,
          raspi.Lights.L21,
          raspi.Lights.L25
        };
      List<LED> makeDiamond = new List<LED>()
        {
          light.L3, light.L7, light.L9, light.L11, light.L15, light.L17, light.L19, light.L23
        };
      //Handling CLI args
      if (args.Length != 0)
      {
        switch (args[0])
        {
          case "disp":
            switch (args[1])
            {
              case "J":
                raspi.DisplayLights(makeJ);
                break;
              case "M":
                raspi.DisplayLights(makeM);
                break;
              case "diamond":
                raspi.DisplayLights(makeDiamond);
                break;
              default:
                Console.WriteLine("No Args match a saved pattern");
                break;
            }
            break;
          case "disptime":
            try
            {
              raspi.SetDisplayTime(int.Parse(args[1]));
            }
            catch
            {
              Console.WriteLine("Invalid time entered (miliseconds)");
            }
            break;
          case "disptest":
            raspi.ReadAllLights();
            isTest = true;
            break;
          case "squareburst":
            raspi.SquareBurst();
            isTest = true;
            break;
        }
        Console.WriteLine("DisplayTime before exit" + raspi.GetDisplayTime());
      }
      if (!isTest)
      {
        bool startSuccess = raspi.Start("https://liteberrypiserver.azurewebsites.net/raspberrypi");
        if (startSuccess)
        {
          raspi.ReadAllLights();
          Console.WriteLine("Press CTRL + C to quit");
          while (true)
          {
          }
        }
        else { Console.WriteLine("Lite-Berry Pi cannot Start."); }
      }
    }
  }
}