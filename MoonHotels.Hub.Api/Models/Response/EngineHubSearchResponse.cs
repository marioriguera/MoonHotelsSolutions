using System.Text.Json.Serialization;

namespace MoonHotels.Hub.Api.Models.Response
{
    /// <summary>
    /// Represents the response from the engine hub search.
    /// </summary>
    public class EngineHubSearchResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EngineHubSearchResponse"/> class with the specified rooms.
        /// </summary>
        /// <param name="rooms">The list of rooms in the response.</param>
        [JsonConstructor]
        public EngineHubSearchResponse(IEnumerable<Room> rooms)
        {
            Rooms = rooms;
        }

        /// <summary>
        /// Gets the list of rooms in the response.
        /// </summary>
        [JsonPropertyName("rooms")]
        public IEnumerable<Room> Rooms { get; } = new List<Room>();
    }
}
