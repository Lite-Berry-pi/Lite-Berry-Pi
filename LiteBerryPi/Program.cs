


using Microsoft.AspNetCore.SignalR.Client;
using RaspberryPi;
using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Threading;
using System.Threading.Tasks;

namespace LiteBerryPi
{
  class Program
  {
    static void Main(string[] args)
    {
      GpioController controller = new GpioController();
      Lights light = new Lights();
      RaspPi raspi = new RaspPi(light, controller);

      //raspi.ReadAllLights();

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


      raspi.ClosePins();
      raspi.OpenPins();
      Console.ReadKey();
      raspi.DisplayLights(makeM);
      raspi.DisplayLights(makeJ);
      raspi.ClosePins();


      //Client Stuff
      Start();
    }    

    public static void Start()
    {
      Console.WriteLine("Running Start");
      try
      {
        Console.WriteLine("Gonna Try");
        var url = "https://liteberrypiserver.azurewebsites.net/raspberrypi";
        Console.WriteLine($"URL: {url}");
        HubConnection connection = new HubConnectionBuilder()
          .WithUrl(url)
          .WithAutomaticReconnect()
          .Build();
        connection.On<string>("TurnLightsOn", (message) => OnReceiveMessage(message));
        
        var t = connection.StartAsync();
        Console.WriteLine("Waiting");
        t.Wait();
        Console.WriteLine("StartAsync: " + connection.ConnectionId);
        Console.WriteLine($"Connected ... ID: {connection.ConnectionId}");

        Console.ReadKey();
      }
      catch (Exception e)
      {
        Console.WriteLine("Never Connected");
        Console.WriteLine(e.Message);
        Console.WriteLine(e.InnerException);

      }
    }

    private static void OnReceiveMessage(string message)
    {
      Console.WriteLine($"Message Received: {message}");
    }

    
    
  }
}
