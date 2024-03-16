using System.Text.Json.Serialization;
using MoonHotels.Hub.Services.Contracts;

namespace MoonHotels.Hub.Api.Models.Response
{
    /// <summary>
    /// Represents a room with its rates.
    /// </summary>
    public class RoomResponse : IRoom
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomResponse"/> class with the specified parameters.
        /// </summary>
        /// <param name="roomId">The ID of the room.</param>
        /// <param name="rates">The list of rates for the room.</param>
        public RoomResponse(int roomId, List<RateResponse> rates)
        {
            RoomId = roomId;
            Rates = (IEnumerable<IRate>)rates;
        }

        /// <inheritdoc/>
        public int RoomId { get; set; }

        /// <inheritdoc/>
        public IEnumerable<IRate> Rates { get; } = new List<IRate>();
    }
}
