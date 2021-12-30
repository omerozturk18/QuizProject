using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public  interface IHubClient
    {
        Task BroadcastMessage();
    }
}
