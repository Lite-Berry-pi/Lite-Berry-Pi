using RaspberryPi;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LiteBerryPi
{
  class Program
  {
    static void Main(string[] args)
    {
      bool noSignalR = false;
      bool noRaspGPIO = false;
      string signalURL = "https://liteberrypisignalrserver.azurewebsites.net/raspi";
      string dispTestPattern = "";
      string animationTestPattern = "";
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
            case "animationtest":
              if (pm.Length >= 2) { animationTestPattern = pm[1]; }
              else { Console.WriteLine("Invalid Test Animation Parameter"); }
              noSignalR = true;
              break;
          }

        }
      }

      Designs designs = new Designs();
      RaspPi raspi = new RaspPi(displayTime, designs, noRaspGPIO);
      Console.WriteLine("No Design Patterns Loaded");
      if (dispTestPattern != "" && !noRaspGPIO) raspi.DisplayPattern(dispTestPattern);
      if (animationTestPattern != "" && !noRaspGPIO) raspi.AnimationDisplay(animationTestPattern);

      if (!noSignalR)
      {
        SignalRClient client = new SignalRClient(signalURL, raspi);
        Console.WriteLine("Starting SignalR Client");
        client.Start().Wait();
        Console.WriteLine("Successfully Connected");
        if (client.ConnectStatus() == "Connected" && noRaspGPIO == false) raspi.ReadAllLights();
        Console.WriteLine("Press CTRL + C to quit");
        double timeStamp = 0;
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        while (client.ConnectStatus() == "Connected")
        {
          if (Console.ReadKey().Key == ConsoleKey.Q) client.Stop().Wait();
          if (Console.ReadKey().Key == ConsoleKey.T) raspi.ReadAllLights(3);
          if (stopwatch.ElapsedMilliseconds > timeStamp)
          {
            timeStamp = stopwatch.ElapsedMilliseconds + 10000;
            Console.WriteLine($"Connect Status: {client.ConnectStatus()} Time Connected: {stopwatch.ElapsedMilliseconds / 1000} seconds");
          }
        }
        stopwatch.Stop();
        Console.WriteLine("Disconnecting from Server");
        
        Console.WriteLine("Total Connected Time: " + stopwatch.ElapsedMilliseconds);
        Console.WriteLine("Have a Great Day!");
      }
    }
   
  }
}