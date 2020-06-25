﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Shadower.Web.Hubs
{
    public class NotificationsHub : Hub
    {
        public async Task NotifyFaceFound(DateTime date, string link)
        {
            await this.Clients.All.SendAsync("UpdateFoundFaces", date, link);
        }
    }
}