using RocketSocket;
using RocketSocket.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lite_Berry_Pi.TestServer
{
    public class SimpleServer : RocketServer
        // RocketServer.cs has config method, just not sure what to config
    {
        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnMessageReceived(ClientSession client, object message)
        {
            base.OnMessageReceived(client, message);
        }
    }
}
