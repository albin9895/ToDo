﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApplication.Hubs
{
    public class NotificationHub : Hub
    {

        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("newMessage", "anonymous", message);
        }

    }
}
