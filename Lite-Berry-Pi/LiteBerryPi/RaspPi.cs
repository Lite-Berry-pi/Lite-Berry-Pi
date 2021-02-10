using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Text;
using System.Threading;

namespace RaspberryPi
{
  public class RaspPi
  {
    public GpioController Controller { get; set; }
    public Lights Lights { get; set; }

    private int[] PinsUsedRows { get; set; }
    private int[] PinsUsedColumns { get;  set; }


    public RaspPi(Lights lights, GpioController controller)
    {      
      Lights = lights;
      Controller = controller;
      PinsUsedRows = new int[] { 5, 6, 13, 19, 26};
      PinsUsedColumns = new int[] { 7, 12, 16, 20, 21 };

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
        Console.WriteLine($"{Controller.IsPinOpen(PinsUsedRows[i])}");
        if (Controller.IsPinOpen(PinsUsedRows[i]))
        {
          Console.WriteLine($"Closing Pin: {PinsUsedRows[i]}");
          Controller.ClosePin(PinsUsedRows[i]);
        }
        Console.WriteLine($"{Controller.IsPinOpen(PinsUsedColumns[i])}");
        if (Controller.IsPinOpen(PinsUsedColumns[i]))
        {
          Console.WriteLine($"Closing Pin: {PinsUsedColumns[i]}");
          Controller.ClosePin(PinsUsedColumns[i]);
        }
      }
    }
    public void OpenPins()
    {
      for(int i = 0; i < PinsUsedRows.Length; i++)
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
      int timesIterated = 0;
      while (timesIterated++ <= 5)
      {

        Console.WriteLine($"AllLights: {Lights.AllLights.Count}  First LED Info: {Lights.AllLights[0].Column}   {Lights.AllLights[0].Row} ");

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
    public void DisplayLights (List<LED> list)
    { 
      Console.WriteLine("The following Lights are being displayed");
      foreach (LED led in list)
      {
        Console.WriteLine($"Light: {led.ID} Col: {led.Column}  Row: {led.Row}");
      } 
      Console.WriteLine("Looping till key pressed");            
      while (!Console.KeyAvailable)
        {
          foreach (LED led in list)
          {
            Controller.Write(led.Column, PinValue.Low);
            Controller.Write(led.Row, PinValue.High);
          //Thread.Sleep(250);
            AllOff();
          }
        }
    }
  }
}
