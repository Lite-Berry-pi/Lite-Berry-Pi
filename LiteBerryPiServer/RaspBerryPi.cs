﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace LiteBerryPiServer
{
    public class RaspBerryPi : Hub
    {
        public override async Task OnConnectedAsync()
        {
            Debug.WriteLine($"Welcome, {Context.ConnectionId}");
            await base.OnConnectedAsync();
        }
        public async Task SendLiteBerry(string designCoords)
        {
            await Clients.All.SendAsync("TurnLightsOn", designCoords);
        }
    public async Task TestConnection(string msg)
    {
      await Clients.All.SendAsync("TestClientConnection", msg);
    }
    }
}