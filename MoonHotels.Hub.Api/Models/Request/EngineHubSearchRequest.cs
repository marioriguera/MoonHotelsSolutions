using MoonHotels.Hub.Services.Contracts;

namespace MoonHotels.Hub.Api.Models.Request
{
    /// <summary>
    /// Represents a search request for the EngineHub.
    /// </summary>
    public class EngineHubSearchRequest : ISearchRoomModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EngineHubSearchRequest"/> class with the specified parameters.
        /// </summary>
        /// <param name="hotelId">The ID of the hotel.</param>
        /// <param name="checkIn">The check-in date.</param>
        /// <param name="checkOut">The check-out date.</param>
        /// <param name="numberOfGuests">The number of guests.</param>
        /// <param name="numberOfRooms">The number of rooms.</param>
        /// <param name="currency">The currency.</param>
        public EngineHubSearchRequest(int hotelId, DateTime checkIn, DateTime checkOut, int numberOfGuests, int numberOfRooms, CurrencyType currency)
        {
            HotelId = hotelId;
            CheckIn = checkIn;
            CheckOut = checkOut;
            NumberOfGuests = numberOfGuests;
            NumberOfRooms = numberOfRooms;
            Currency = currency;
        }

        /// <inheritdoc/>
        public int HotelId { get; }

        /// <inheritdoc/>
        public DateTime CheckIn { get; }

        /// <inheritdoc/>
        public DateTime CheckOut { get; }

        /// <inheritdoc/>
        public int NumberOfGuests { get; }

        /// <inheritdoc/>
        public int NumberOfRooms { get; }

        /// <inheritdoc/>
        public CurrencyType Currency { get; }

        /// <inheritdoc/>
        public int IdSearch => this.GetHashCode();

        /// <summary>
        /// Gets a list of invalidations for the search request.
        /// </summary>
        /// <returns>A list of invalidations, if any.</returns>
        internal List<string> Invalidations()
        {
            List<string> invalidations = new();

            if (HotelId <= 0)
                invalidations.Add("HotelId must be greater than 0.");

            if (CheckIn >= CheckOut)
                invalidations.Add("CheckOut date must be greater than CheckIn date.");

            if (NumberOfGuests <= 0)
                invalidations.Add("NumberOfGuests must be greater than 0.");

            if (NumberOfRooms <= 0)
                invalidations.Add("NumberOfRooms must be greater than 0.");

            if (!Enum.IsDefined(typeof(CurrencyType), Currency))
                invalidations.Add("Currency is not a valid currency type.");

            return invalidations;
        }

        /// <summary>
        /// Checks whether the search request is valid.
        /// </summary>
        /// <returns>True if the search request is valid; otherwise, false.</returns>
        internal bool IsValid()
        {
            return !Invalidations().Any();
        }
    }
}
