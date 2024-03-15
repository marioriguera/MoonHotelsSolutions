using System.Text.Json.Serialization;

namespace MoonHotels.Hub.Api.Models.Response
{
    /// <summary>
    /// Represents a room with its rates.
    /// </summary>
    public class Room
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class with the specified parameters.
        /// </summary>
        /// <param name="roomId">The ID of the room.</param>
        /// <param name="rates">The list of rates for the room.</param>
        [JsonConstructor]
        public Room(int roomId, List<Rate> rates)
        {
            RoomId = roomId;
            Rates = rates;
        }

        /// <summary>
        /// Gets the ID of the room.
        /// </summary>
        public int RoomId { get; }

        /// <summary>
        /// Gets the list of rates for the room.
        /// </summary>
        public IReadOnlyList<Rate> Rates { get; }
    }
}
