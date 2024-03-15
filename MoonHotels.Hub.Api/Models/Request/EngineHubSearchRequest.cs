namespace MoonHotels.Hub.Api.Models.Request
{
    /// <summary>
    /// Represents types of currencies.
    /// </summary>
    public enum CurrencyType
    {
        /// <summary>
        /// United States Dollar (USD).
        /// </summary>
        USD,

        /// <summary>
        /// Euro (EUR).
        /// </summary>
        EUR,

        /// <summary>
        /// British Pound Sterling (GBP).
        /// </summary>
        GBP,

        /// <summary>
        /// Japanese Yen (JPY).
        /// </summary>
        JPY,

        /// <summary>
        /// Australian Dollar (AUD).
        /// </summary>
        AUD,

        /// <summary>
        /// Canadian Dollar (CAD).
        /// </summary>
        CAD,

        /// <summary>
        /// Swiss Franc (CHF).
        /// </summary>
        CHF,

        /// <summary>
        /// Chinese Yuan Renminbi (CNY).
        /// </summary>
        CNY,

        /// <summary>
        /// Swedish Krona (SEK).
        /// </summary>
        SEK,

        /// <summary>
        /// New Zealand Dollar (NZD).
        /// </summary>
        NZD,
    }

    /// <summary>
    /// Represents a search request for the EngineHub.
    /// </summary>
    public class EngineHubSearchRequest
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

        /// <summary>
        /// Gets the ID of the hotel.
        /// </summary>
        public int HotelId { get; }

        /// <summary>
        /// Gets the check-in date.
        /// </summary>
        public DateTime CheckIn { get; }

        /// <summary>
        /// Gets the check-out date.
        /// </summary>
        public DateTime CheckOut { get; }

        /// <summary>
        /// Gets the number of guests.
        /// </summary>
        public int NumberOfGuests { get; }

        /// <summary>
        /// Gets the number of rooms.
        /// </summary>
        public int NumberOfRooms { get; }

        /// <summary>
        /// Gets the currency.
        /// </summary>
        public CurrencyType Currency { get; }

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
