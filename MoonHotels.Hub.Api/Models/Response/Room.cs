using System.Text.Json.Serialization;

namespace MoonHotels.Hub.Api.Models.Response
{

    public class Room
    {
        [JsonConstructor]
        public Room(
            int roomId,
            List<Rate> rates
        )
        {
            this.RoomId = roomId;
            this.Rates = rates;
        }

        public int RoomId { get; }
        public IReadOnlyList<Rate> Rates { get; }
    }
}
