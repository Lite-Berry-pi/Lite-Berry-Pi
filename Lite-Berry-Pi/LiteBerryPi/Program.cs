using RaspberryPi;
using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Threading;

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

      MakeAJ(raspi);


    }
    
    static void MakeAJ(RaspPi raspPi)
    {
      List<LED> makeJ = new List<LED>();
      Console.WriteLine($"Col: {raspPi.Lights.L5.Column}  Row: {raspPi.Lights.L5.Row}");
      makeJ.Add(raspPi.Lights.L3);
      makeJ.Add(raspPi.Lights.L8);
      makeJ.Add(raspPi.Lights.L13);
      makeJ.Add(raspPi.Lights.L16);
      makeJ.Add(raspPi.Lights.L18);
      makeJ.Add(raspPi.Lights.L21);
      makeJ.Add(raspPi.Lights.L22);
      makeJ.Add(raspPi.Lights.L23);


      raspPi.OpenPins();
      while (!Console.KeyAvailable)
      {
        foreach (LED led in makeJ)
        {
          raspPi.Controller.Write(led.Column, PinValue.Low);
          raspPi.Controller.Write(led.Row, PinValue.High);
          raspPi.AllOff();
        }
      }
        raspPi.ClosePins();
    }    
  }
}
