using System.Text.Json.Serialization;

namespace MoonHotels.Hub.Api.Models.Response
{
    public class EngineHubSearchResponse
    {
        [JsonConstructor]
        public EngineHubSearchResponse(
            List<Room> rooms
        )
        {
            Rooms = rooms;
        }

        [JsonPropertyName("rooms")]
        public IReadOnlyList<Room> Rooms { get; }
    }
}
