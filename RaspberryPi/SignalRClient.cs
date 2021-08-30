using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace RaspberryPi
{
  public class SignalRClient
  {
    private string _url;    
    
    public SignalRClient(string url){
      _url = url; 
    }
    public async Task<bool> Start()
    {
      Console.WriteLine("Running Start");
      try
      {        
        Console.WriteLine($"URL: {_url}");
        HubConnection connection = new HubConnectionBuilder()
          .WithUrl(_url)
          .WithAutomaticReconnect()
          .Build();

        await connection.StartAsync();
        Console.WriteLine("Waiting");

        Console.WriteLine("StartAsync: " + connection.ConnectionId);
        //Console.WriteLine($"Connected ... ID: {connection.ConnectionId}");
        connection.On<string>("TurnLightsOn", (message) => OnReceiveMessage(message));
        return true;
      }
      catch (Exception e)
      {
        Console.WriteLine("Error Connecting");
        Console.WriteLine(e.Message);
        Console.WriteLine(e.InnerException);
        return false;
      }
    }
    /// <summary>
    /// When message is received from the server, it converts the message and 
    /// invokes the DisplayLights Method.
    /// </summary>
    /// <param name="message"></param>
    private void OnReceiveMessage(string message)
    {
      Console.WriteLine($"Message Received: {message}");      
    }
  }
}
