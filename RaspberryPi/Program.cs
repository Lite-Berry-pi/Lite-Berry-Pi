using RaspberryPi;
using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Threading.Tasks;

namespace LiteBerryPi
{
  class Program
  {
    static void Main(string[] args)
    {
      bool noSignalR = false;
      bool noRaspGPIO = false;
      string signalURL = "http://liteberrypi.service.signalr.net";
      string dispTestPattern = "";
      int displayTime = 5000;


      // Initial Raspberry Pi GPIO and Light Grid setup
      if (args.Length > 0)
      {
        Console.WriteLine($"argsLength:{ args.Length}");
        //handles args 
        foreach (string s in args)
        {
          string[] pm = s.Split('=');
          int lenPm = pm.Length;
          Console.WriteLine($"args: {s}");

          switch (pm[0].ToLower())
          {
            case "url":
              if (pm.Length >= 2) { signalURL = pm[1]; }
              else { Console.WriteLine("No URL Given. (eg URL:http://example.com)"); }
              break;
            case "norasp":
              noRaspGPIO = true;
              break;
            case "disp":
              if (pm.Length >= 2) { dispTestPattern = pm[1]; }
              else { Console.WriteLine("No Pattern selected."); }
              noSignalR = true;
              break;
            case "disptest":
              dispTestPattern = pm[0];
              noSignalR = true;
              Console.WriteLine("Running Light Runner Test");
              break;
            case "disptime":
              Int32.TryParse(pm[1], out displayTime);
              break;
          }

        }
      }
      if (!noRaspGPIO)
      {
        RaspPi raspi = new RaspPi(displayTime);
        Designs designs = new Designs();
        if (dispTestPattern != "") DisplayPattern(dispTestPattern, designs, raspi);
      }
      if (!noSignalR)
      {
        SignalRClient client = new SignalRClient(signalURL);
        Console.WriteLine("Starting SignalR Client");
        client.Start().Wait();
        Console.WriteLine("Successfully Connected");
        Console.WriteLine("Press CTRL + C to quit");
      }
    }
    public static void DisplayPattern( string pattern, Designs designs, RaspPi raspi)
    {
      List<LED> desiredPattern = designs.Pattern[pattern];
      if (pattern == "disptest")
      {
        raspi.ReadAllLights();
      }
      else if (desiredPattern != null)
      {
      raspi.DisplayLights(desiredPattern);      
      }
      
      else
      {
        Console.WriteLine("No Patterns match desired input");
      }
      
      
      
    }
  }
}