using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace RaspberryPi
{
  public class RaspPi
  {
    public GpioController Controller { get; set; }
    public Lights Lights { get; set; }
    private int[] PinsUsedRows { get; set; }
    private int[] PinsUsedColumns { get; set; }
    private int TimeInterval { get; set; }
    public RaspPi()
    {
      Lights = new Lights();
      Controller = new GpioController();
      SetPinColAndRows();
      TimeInterval = 5000;
      ClosePins();
    }
    public RaspPi(int timeInterval)
    {
      Lights = new Lights();
      Controller = new GpioController();
      SetPinColAndRows();
      TimeInterval = timeInterval;
      ClosePins();
    }
    /// <summary>
    /// Sets the Columns and Rows for the LED matrix.
    /// </summary>
    private void SetPinColAndRows()
    {
      PinsUsedRows = new int[] { 5, 6, 13, 19, 26 };
      PinsUsedColumns = new int[] { 7, 12, 16, 20, 21 };
    }
    /// <summary>
    /// Set's the private integer TimeInterval for LED display
    /// (milliseconds)
    /// </summary>
    /// <param name="time"></param>
    public void SetDisplayTime(int time = 5000)
    {
      TimeInterval = time;
    }
    /// <summary>
    /// Returns the Value of the TimeInterval
    /// </summary>
    /// <returns></returns>
    public int GetDisplayTime()
    {
      return TimeInterval;
    }
    /// <summary>
    /// Turns All LEDs in the Grid to Off
    /// </summary>
    public void AllOff()
    {
      for (int i = 0; i < PinsUsedRows.Length; i++)
      {
        Controller.Write(PinsUsedRows[i], PinValue.Low);
        Controller.Write(PinsUsedColumns[i], PinValue.High);
      }
    }
    /// <summary>
    /// Closes Pins used on the LiteBerry Pi when manipulation complete
    /// </summary>
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
    /// <summary>
    /// Open all pins for manipulation
    /// </summary>
    public void OpenPins()
    {
      Console.WriteLine("Opening Pins");
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
    /// <summary>
    /// /// Display Test Of All Lights in the grid being lit up in a cycling pattern
    /// Parameter: Number of times to perform the cycle.
    /// </summary>
    /// <param name="loop"></param>
    public void ReadAllLights(int loop = 2)
    {
      OpenPins();
      int timesIterated = 0;
      while (timesIterated++ <= loop)
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
    /// <summary>
    /// Takes in a Lost of LED objects and will scan them for the desired
    /// length of time.  Determined by TimeInterval Property
    /// </summary>
    /// <param name="list"></param>

    public void DisplayLights(List<LED> list)
    {
      Stopwatch stopW = new Stopwatch();
      stopW.Start();
      Console.WriteLine("Starting Display Lights");
      ClosePins();
      OpenPins();
      
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
    /// <summary>
    /// This will start the Async Connection to the Hub Server, and wait for input.
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    
    public void SquareBurst()
    {
      int ogTimeInterval = TimeInterval;
      TimeInterval = 500;
      List<LED> stepOne = new List<LED>() { Lights.L13 };
      List<LED> stepTwo = new List<LED>() { Lights.L8, Lights.L12, Lights.L14, Lights.L18 };
      List<LED> stepThree = new List<LED>() { Lights.L3, Lights.L7, Lights.L9, Lights.L11, Lights.L15, Lights.L17, Lights.L19, Lights.L23 };
      List<LED> stepFour = new List<LED>() { Lights.L2, Lights.L4, Lights.L6, Lights.L10, Lights.L16, Lights.L22, Lights.L24, Lights.L20 };
      List<LED> stepFive = new List<LED>() { Lights.L1, Lights.L5, Lights.L21, Lights.L25};
      DisplayLights(stepOne);
      DisplayLights(stepTwo);
      DisplayLights(stepThree);
      DisplayLights(stepFour);
      DisplayLights(stepFive);
            
      DisplayLights(stepFive);
      DisplayLights(stepFour);
      DisplayLights(stepThree);
      DisplayLights(stepTwo);
      DisplayLights(stepOne);

      TimeInterval = ogTimeInterval;

    }
    
  }
}
