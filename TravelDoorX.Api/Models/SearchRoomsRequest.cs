using TravelDoorX.Services.Contracts;

namespace TravelDoorX.Api.Models
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
        /// <param name="hasWifi">If the room has wifi.</param>
        /// <param name="hasDinner">If the reservation includes a dinner.</param>
        /// <param name="hasPool">If the hotel include a pool.</param>
        public SearchRoomsRequest(int hotel, DateTime checkInDate, int numberOfNights, int guests, int rooms, CurrencyType currency, bool hasWifi, bool hasDinner, bool hasPool)
        {
            Hotel = hotel;
            CheckInDate = checkInDate;
            NumberOfNights = numberOfNights;
            Guests = guests;
            Rooms = rooms;
            Currency = currency;
            HasWifi = hasWifi;
            HasDinner = hasDinner;
            HasPool = hasPool;
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

        /// <inheritdoc/>
        public bool HasWifi { get; set; }

        /// <inheritdoc/>
        public bool HasDinner { get; set; }

        /// <inheritdoc/>
        public bool HasPool { get; set; }
    }
}
