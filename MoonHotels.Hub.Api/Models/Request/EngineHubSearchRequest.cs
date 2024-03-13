using System.Text.Json.Serialization;

namespace MoonHotels.Hub.Api.Models.Request
{
    public class EngineHubSearchRequest
    {
        [JsonConstructor]
        public EngineHubSearchRequest(
            int hotelId,
            string checkIn,
            string checkOut,
            int numberOfGuests,
            int numberOfRooms,
            string currency
        )
        {
            HotelId = hotelId;
            CheckIn = checkIn;
            CheckOut = checkOut;
            NumberOfGuests = numberOfGuests;
            NumberOfRooms = numberOfRooms;
            Currency = currency;
        }

        public int HotelId { get; }
        public string CheckIn { get; }
        public string CheckOut { get; }
        public int NumberOfGuests { get; }
        public int NumberOfRooms { get; }
        public string Currency { get; }
    }
}
