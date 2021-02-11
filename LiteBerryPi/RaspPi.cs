using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Diagnostics;
using System.Threading;

namespace RaspberryPi
{
  public class RaspPi
  {
    public GpioController Controller { get; set; }
    public Lights Lights { get; set; }

    private int[] PinsUsedRows { get; set; }
    private int[] PinsUsedColumns { get; set; }
    private int TimeInterval { get; set; }
    public RaspPi(Lights lights, GpioController controller)
    {      
      Lights = lights;
      Controller = controller;
      PinsUsedRows = new int[] { 5, 6, 13, 19, 26 };
      PinsUsedColumns = new int[] { 7, 12, 16, 20, 21 };
      TimeInterval = 5000;     
    }
    public void SetDisplayTime(int time = 5000)
    {
      TimeInterval = time;
    }
    public int GetDisplayTime()
    {
      return TimeInterval;
    }
    public void AllOff()
    {
      for (int i = 0; i < PinsUsedRows.Length; i++)
      {
        Controller.Write(PinsUsedRows[i], PinValue.Low);
        Controller.Write(PinsUsedColumns[i], PinValue.High);
      }
    }
    public void ClosePins()
    {
      for (int i = 0; i < PinsUsedRows.Length; i++)
      {
        
        if (Controller.IsPinOpen(PinsUsedRows[i]))
        {
          
          Controller.ClosePin(PinsUsedRows[i]);
        }
       
        if (Controller.IsPinOpen(PinsUsedColumns[i]))
        {
          
          Controller.ClosePin(PinsUsedColumns[i]);
        }
      }
    }
    public void OpenPins()
    {
      for (int i = 0; i < PinsUsedRows.Length; i++)
      {
        //Open pins
        Controller.OpenPin(PinsUsedRows[i]);
        Controller.OpenPin(PinsUsedColumns[i]);
        //Set pin mode to output
        Controller.SetPinMode(PinsUsedRows[i], PinMode.Output);
        Controller.SetPinMode(PinsUsedColumns[i], PinMode.Output);
        //Set pins to default state
      }
      AllOff();
    }
    public void ReadAllLights()
    {
      OpenPins();
      int timesIterated = 0;
      while (timesIterated++ <= 1)
      {
       

        foreach (LED led in Lights.AllLights)
        {

          Controller.Write(led.Row, PinValue.High);
          Controller.Write(led.Column, PinValue.Low);

          Thread.Sleep(50);

          Controller.Write(led.Row, PinValue.Low);
          Controller.Write(led.Column, PinValue.High);
        }
      }
      ClosePins();
    }
    public void DisplayLights(List<LED> list)
    {
      Stopwatch stopW = new Stopwatch();
      stopW.Start();
      Console.WriteLine("Starting Display Lights");      
      ClosePins();
      OpenPins();
      


      foreach (LED led in list) { Console.WriteLine($"LEDs: {led.ID}"); }
      
      long counter = stopW.ElapsedMilliseconds;

      while (stopW.ElapsedMilliseconds <= counter + TimeInterval)
      {
        
        foreach (LED led in list)
        {
          
          Controller.Write(led.Column, PinValue.Low);
          Controller.Write(led.Row, PinValue.High);
          //Thread.Sleep(250);
          AllOff();
        }
        
      }
      stopW.Stop();
      Console.WriteLine("Closing Pins");
      ClosePins();
    }
    public bool Start(string url)
    {
      Console.WriteLine("Running Start");
      try
      {
        Console.WriteLine("Gonna Try");

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
        return true;
      }
      catch (Exception e)
      {
        Console.WriteLine("Never Connected");
        Console.WriteLine(e.Message);
        Console.WriteLine(e.InnerException);
        return false;
      }
    }
    private void OnReceiveMessage(string message)
    {
      Console.WriteLine($"Message Received: {message}");
      List<LED> displayMessage = Lights.CreateLightPattern(message);
      Console.WriteLine("Sending the following to Display lights");
      foreach(LED led in displayMessage) { Console.Write($"{led.ID}, "); }
      Console.WriteLine();
      DisplayLights(displayMessage);
    }
  }
}
