using Microsoft.AspNetCore.SignalR;

namespace WEB.API.Hubs
{
    public class MessageHub : Hub
    {
        public async Task MessageSent(string message)
        {
            await Clients.All.SendAsync("MessageSend", message);
        }
    }
}
