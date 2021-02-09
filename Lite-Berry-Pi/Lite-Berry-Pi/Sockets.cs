using Newtonsoft.Json;
using SocketIOClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace sockets
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var uri = new Uri("http://109f44c81d60.ngrok.io");
            var socket = new SocketIO(uri);
            socket.OnConnected += Socket_OnConnected;
            socket.On("hi", response =>
            {
                Console.WriteLine($"server: {response.GetValue<string>()}");
            });
            await socket.ConnectAsync();
            Console.WriteLine("Press any key to quit (hopefully, the server wrote you back");
            Console.ReadKey();
        }
        private static async void Socket_OnConnected(object sender, EventArgs e)
        {
            var socket = sender as SocketIO;
            await socket.EmitAsync("hello", "C# App");
        }
    }
}
