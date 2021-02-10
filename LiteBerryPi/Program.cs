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

      // Initial Raspberry Pi GPIO and Light Grid setup
      GpioController controller = new GpioController();
      Lights light = new Lights();
      RaspPi raspi = new RaspPi(light, controller);
      raspi.ClosePins();
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
        }

        Console.WriteLine("DisplayTime before exit" + raspi.GetDisplayTime());
      }

      // Just some sample, remove before completion of project
      //raspi.ReadAllLights();

      //raspi.DisplayLights(makeDiamond);

      //raspi.DisplayLights(makeJ);

      //raspi.DisplayLights(makeDiamond);






      // Connect to the Websocket, supply the URL

      bool startSuccess = raspi.Start("https://liteberrypiserver.azurewebsites.net/raspberrypi");
      if (startSuccess)
      {
        Console.WriteLine("Press CTRL + C to quit");
        while (true)
       {

        }
      }
      else { Console.WriteLine("Lite-Berry Pi cannot Start."); }


      //Console.WriteLine("Web Socket Started.  Press CTRL + C to exit the App");
      //while (true)
      //{


      //  if (swatch.ElapsedMilliseconds >= 5000)
      //  {
      //    swatch.Reset();
      //    Console.WriteLine("5 seconds you all!");
      //    swatch.Start();
      //  }
      //}

    }
    /// <summary>
    /// Connects the LiteBerry Pi to the WebServer Hub via supplied URL
    /// </summary>
    /// <param name="url"></param>
    //public static void Start(string url)
    //{
    //  Console.WriteLine("Running Start");
    //  try
    //  {
    //    Console.WriteLine("Gonna Try");

    //    Console.WriteLine($"URL: {url}");
    //    HubConnection connection = new HubConnectionBuilder()
    //      .WithUrl(url)
    //      .WithAutomaticReconnect()
    //      .Build();
    //    connection.On<string>("TurnLightsOn", (message) => OnReceiveMessage(message));

    //    var t = connection.StartAsync();
    //    Console.WriteLine("Waiting");
    //    t.Wait();
    //    Console.WriteLine("StartAsync: " + connection.ConnectionId);
    //    Console.WriteLine($"Connected ... ID: {connection.ConnectionId}");
    //  }
    //  catch (Exception e)
    //  {
    //    Console.WriteLine("Never Connected");
    //    Console.WriteLine(e.Message);
    //    Console.WriteLine(e.InnerException);

    //  }
    //}
    /// <summary>
    /// Converts incoming data to a LED list, display Data.
    /// </summary>
    /// <param name="message"></param>




  }
}
