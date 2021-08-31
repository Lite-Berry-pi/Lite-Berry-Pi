using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaspberryPi
{
  public class SignalRClient
  {
    private string _url;
    private HubConnection _Connection { get; set; }
    private RaspPi _Raspi { get; set; }

    public SignalRClient(string url)
    {
      _url = url;
      _Connection = new HubConnectionBuilder()
          .WithUrl(url)
          .WithAutomaticReconnect()
          .Build();
    }
    public SignalRClient(string url, RaspPi raspi)
    {
      _url = url;
      _Raspi = raspi;
      _Connection = new HubConnectionBuilder()
          .WithUrl(url)
          .WithAutomaticReconnect()
          .Build();
    }
    public async Task Start()
    {
      Console.WriteLine("Running Start");
      try
      {
        Console.WriteLine($"URL: {_url}");


        await _Connection.StartAsync();
        Console.WriteLine("Waiting");
        var str = _Connection.State.ToString();
        Console.WriteLine("Connection: " + str);
        Console.WriteLine("StartAsync: " + _Connection.ConnectionId);
        Console.WriteLine($"Connected ... ID: {_Connection.ConnectionId}");
        //When received the TurnLights on.  (fromHubMethodCall, Callback to run clientmethod
        _Connection.On<string>("TurnLightsOn", (designCoords) => DisplayDesign(designCoords));
        _Connection.On<string>("DisplayStandardDesign", (key) => DisplayStandardDesign(key));
      }
      catch (Exception e)
      {
        Console.WriteLine("Error Connecting");
        Console.WriteLine(e.Message);
        Console.WriteLine(e.InnerException);
      }
    }
    public async Task Stop()
    {
      await _Connection.StopAsync();
      await _Connection.DisposeAsync();
      Console.WriteLine("Connection Stopped");
    }
    /// <summary>
    /// Checks Connection Status and return result as a string
    /// </summary>
    /// <returns></returns>
    public string ConnectStatus()
    {
      return _Connection.State.ToString();
    }
    /// <summary>
    /// When message is received from the server, it converts the message and 
    /// invokes the DisplayLights Method.
    /// </summary>
    /// <param name="message"></param>
    private void DisplayDesign(string designCoords)
    {
      Console.WriteLine($"Message Received: {designCoords}");
      List<LED> lightToDisplay = _Raspi.Lights.CreateLightPattern(designCoords);
      _Raspi.DisplayLights(lightToDisplay);
    }
    private void DisplayStandardDesign(string key)
    {
      Console.WriteLine($"Received Request for StandardDesign {key}");
      string[] typeKey = key.Split(":");
      Console.WriteLine($"Split key: {typeKey[0]} {typeKey[1]}");
      if (typeKey[0].ToLower() == "animation")
      {
        Console.WriteLine("Animation Selected");
        if (_Raspi == null) Console.WriteLine("_Raspi is null");
        if (_Raspi != null) _Raspi.AnimationDisplay(typeKey[1].ToUpper());
      }
      else if (typeKey[0].ToLower() == "static")
      {
        Console.WriteLine("Static Design Selected");
        if (_Raspi != null) _Raspi.DisplayPattern(typeKey[1].ToUpper());
      }
      else
      {
        Console.WriteLine("Correct Type Not Given");
        return;
      }
      

    }
  }
}
