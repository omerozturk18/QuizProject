using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Entities.Concrete
{
    public class BroadcastHub : Hub
    {
        public async Task SendMessage(Quiz quiz)
        { 
            await Clients.All.SendAsync("Send", quiz);

        }

    }
}
