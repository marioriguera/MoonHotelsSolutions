using MoonHotels.Hub.Services.Contracts;

namespace MoonHotels.Hub.Services.Models
{
    /// <summary>
    /// Represents a room with its rates.
    /// </summary>
    internal class Room : IRoom
    {
        /// <inheritdoc/>
        public int RoomId { get; set; }

        /// <inheritdoc/>
        public IEnumerable<IRate> Rates { get; } = new List<Rate>();
    }
}