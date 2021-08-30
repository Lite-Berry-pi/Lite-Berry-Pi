using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace RaspberryPi
{
  public class SignalRClient
  {
    private string _url;
    private HubConnection Connection { get; set; }

    public SignalRClient(string url)
    {
      _url = url;
      Connection = new HubConnectionBuilder()
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


        await Connection.StartAsync();
        Console.WriteLine("Waiting");
        var str = Connection.State.ToString();
        Console.WriteLine("Connection: " + str);
        Console.WriteLine("StartAsync: " + Connection.ConnectionId);
        Console.WriteLine($"Connected ... ID: {Connection.ConnectionId}");
        //When recieved the TurnLights on.  (fromHubMethodCall, Callback to run clientmethod
        Connection.On<string>("TurnLightsOn", (message) => OnReceiveMessage(message));
      }
      catch (Exception e)
      {
        Console.WriteLine("Error Connecting");
        Console.WriteLine(e.Message);
        Console.WriteLine(e.InnerException);
      }
    }
    /// <summary>
    /// Checks Connection Status and return result as a string
    /// </summary>
    /// <returns></returns>
    public string ConnectStatus()
    {
      return Connection.State.ToString();
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
