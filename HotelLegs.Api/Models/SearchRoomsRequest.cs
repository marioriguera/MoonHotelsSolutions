using HotelLegs.Services.Contracts;

namespace HotelLegs.Api.Models
{
    /// <summary>
    /// Represents a request for searching rooms.
    /// </summary>
    public class SearchRoomsRequest : ISearchRoomModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchRoomsRequest"/> class with the specified parameters.
        /// </summary>
        /// <param name="hotel">The ID of the hotel.</param>
        /// <param name="checkInDate">The check-in date.</param>
        /// <param name="numberOfNights">The number of nights for the stay.</param>
        /// <param name="guests">The number of guests.</param>
        /// <param name="rooms">The number of rooms.</param>
        /// <param name="currency">The currency type.</param>
        public SearchRoomsRequest(int hotel, DateTime checkInDate, int numberOfNights, int guests, int rooms, CurrencyType currency)
        {
            Hotel = hotel;
            CheckInDate = checkInDate;
            NumberOfNights = numberOfNights;
            Guests = guests;
            Rooms = rooms;
            Currency = currency;
        }

        /// <inheritdoc/>
        public int Hotel { get; set; }

        /// <inheritdoc/>
        public DateTime CheckInDate { get; set; }

        /// <inheritdoc/>
        public int NumberOfNights { get; set; }

        /// <inheritdoc/>
        public int Guests { get; set; }

        /// <inheritdoc/>
        public int Rooms { get; set; }

        /// <inheritdoc/>
        public CurrencyType Currency { get; set; }
    }
}
