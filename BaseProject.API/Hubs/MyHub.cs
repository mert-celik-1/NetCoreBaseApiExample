using BaseProject.Core;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProject.API.Hubs
{
    public class MyHub:Hub
    {
        // Kestrel (http) sunucusu tarafından postman web socket request ile test edilmiştir.
        public static List<Article> Articles { get; set; } = new List<Article>();
        private static int ClientCount { get; set; } = 0;

        public async Task SendName(Article article)
        {
            Articles.Add(article);

            await Clients.All.SendAsync("ReceiveProduct", article);
        }

        public async Task GetNames()
        {
            await Clients.All.SendAsync("ReceiveProducts", Articles);
        }

        public async override Task OnConnectedAsync()
        {
            ClientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", ClientCount);

            await base.OnConnectedAsync();
        }

        public async override Task OnDisconnectedAsync(Exception exception)
        {
            ClientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", ClientCount);

            await base.OnDisconnectedAsync(exception);
        }
    }
}
