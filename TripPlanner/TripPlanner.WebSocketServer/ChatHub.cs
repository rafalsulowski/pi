using Microsoft.AspNetCore.SignalR;

namespace TripPlanner.WebSocketServer
{
    public sealed class ChatHub : Hub
    {
        //public override async Task OnConnectedAsync()
        //{
        //    await Clients.All.SendMessage("", $"{Context.ConnectionId} has joined");
        //}

        //public async Task SendMessage(string message)
        //{
        //    await Clients.All.SendMessage("", $"{Context.ConnectionId}: {message}");
        //}


        public Task SendMessage(string user, string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", user, message);
        }

    }
}
