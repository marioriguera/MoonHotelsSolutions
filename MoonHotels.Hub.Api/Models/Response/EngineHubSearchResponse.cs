using System.Text.Json.Serialization;
using MoonHotels.Hub.Services.Contracts;

namespace MoonHotels.Hub.Api.Models.Response
{
    /// <summary>
    /// Represents the response from the engine hub search.
    /// </summary>
    public class EngineHubSearchResponse : IEngineHub
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EngineHubSearchResponse"/> class with the specified rooms.
        /// </summary>
        /// <param name="rooms">The list of rooms in the response.</param>
        [JsonConstructor]
        public EngineHubSearchResponse(IEnumerable<RoomResponse> rooms)
        {
            Rooms = rooms;
        }

        /// <inheritdoc/>
        [JsonPropertyName("rooms")]
        public IEnumerable<IRoom> Rooms { get; } = new List<RoomResponse>();
    }
}
