using MoonHotels.Hub.Services.Contracts;

namespace MoonHotels.Hub.Services.Models
{
    /// <summary>
    /// Represents an engine hub with its rooms.
    /// </summary>
    internal class EngineHub : IEngineHub
    {
        /// <inheritdoc/>
        public IEnumerable<IRoom> Rooms { get; } = new List<Room>();
    }
}
