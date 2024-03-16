using MoonHotels.Hub.Services.Contracts;

namespace MoonHotels.Hub.Services.Models
{
    /// <summary>
    /// Represents an engine hub with its rooms.
    /// </summary>
    internal class EngineHub : IEngineHub
    {
        public EngineHub(IEnumerable<IRoom> rooms)
        {
            Rooms = rooms;
        }

        /// <inheritdoc/>
        public IEnumerable<IRoom> Rooms { get; } = new List<Room>();
    }
}
