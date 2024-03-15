using Microsoft.AspNetCore.SignalR;

namespace MoonHotels.Hub.Api.Hub
{
    /// <summary>
    /// Represents a hub for Moon Hotels communication using SignalR.
    /// </summary>
    public sealed class MoonHotelsHub : Microsoft.AspNetCore.SignalR.Hub
    {
        /// <summary>
        /// Overrides the method called when a client connects to the hub.
        /// </summary>
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("ReceiveMessage", $"{Context.ConnectionId} has joined. ");
        }

        /// <summary>
        /// Overrides the method called when a client disconnects from the hub.
        /// </summary>
        /// <param name="exception">The exception that caused the disconnection, if any.</param>
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.All.SendAsync("ReceiveMessage", $"{Context.ConnectionId} has disconnected. ");
        }

        /// <summary>
        /// Sends a message to all connected clients.
        /// </summary>
        /// <param name="message">The message to send.</param>
        public async Task SendMessageToAll(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", $"{Context.ConnectionId} : {message}. ");
        }
    }
}
