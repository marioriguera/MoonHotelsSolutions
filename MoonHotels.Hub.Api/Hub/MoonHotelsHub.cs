using Microsoft.AspNetCore.SignalR;

namespace MoonHotels.Hub.Api.Hub
{
    public sealed class MoonHotelsHub : Microsoft.AspNetCore.SignalR.Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("ReceiveMessage", $"{Context.ConnectionId} has joined. ");
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.All.SendAsync("ReceiveMessage", $"{Context.ConnectionId} has disconnected. ");
        }

        public async Task SendMessageToAll(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", $"{Context.ConnectionId} : {message}. ");
        }
    }
}
