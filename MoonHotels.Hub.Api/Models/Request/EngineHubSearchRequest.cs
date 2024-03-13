using System.Text.Json.Serialization;

namespace MoonHotels.Hub.Api.Models.Request
{
    public class EngineHubSearchRequest
    {
        public EngineHubSearchRequest(
            int hotelId,
            DateTime checkIn,
            DateTime checkOut,
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
        public DateTime CheckIn { get; }
        public DateTime CheckOut { get; }
        public int NumberOfGuests { get; }
        public int NumberOfRooms { get; }
        public string Currency { get; }

        internal bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
