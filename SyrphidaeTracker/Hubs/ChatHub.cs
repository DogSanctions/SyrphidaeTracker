using Microsoft.AspNetCore.SignalR;

namespace SyrphidaeTracker.Hubs
{
    public class ChatHub : Hub
    {
        public Task SendMessage(string user, string message)
        {
            return Clients.All.SendAsync(method: "RecieveMessage", user, message);
        }
    }
}
