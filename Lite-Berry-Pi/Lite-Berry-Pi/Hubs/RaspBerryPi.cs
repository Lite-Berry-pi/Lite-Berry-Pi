using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Lite_Berry_Pi.Hubs
{
    public class RaspBerryPi : Hub
    {
        public async Task SendLiteBerry(string designCoords)
        {
            // send the stuff to the raspberry

            await Clients.All.SendAsync("sent the thing", designCoords);
        }
        
        public async Task ReceiveLiteBerry(string designCoords)
        {
            //get the stuff from the route
            // call other method

            await Clients.All.SendAsync("got the thing", designCoords);
        }
    }
}
