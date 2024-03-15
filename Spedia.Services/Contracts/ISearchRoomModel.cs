namespace Spedia.Services.Contracts
{
    /// <summary>
    /// Represents the model for searching rooms.
    /// </summary>
    public interface ISearchRoomModel
    {
        /// <summary>
        /// Gets or sets the ID of the hotel.
        /// </summary>
        int Hotel { get; set; }

        /// <summary>
        /// Gets or sets the check-in date.
        /// </summary>
        DateTime CheckInDate { get; set; }

        /// <summary>
        /// Gets or sets the number of nights for the stay.
        /// </summary>
        int NumberOfNights { get; set; }

        /// <summary>
        /// Gets or sets the number of guests.
        /// </summary>
        int Guests { get; set; }

        /// <summary>
        /// Gets or sets the number of rooms.
        /// </summary>
        int Rooms { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the number of rooms.
        /// </summary>
        bool HasWifi { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the number of rooms.
        /// </summary>
        bool HasDinner { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        CurrencyType Currency { get; set; }
    }
}