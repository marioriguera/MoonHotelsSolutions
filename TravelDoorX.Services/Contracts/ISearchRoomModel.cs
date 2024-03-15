namespace TravelDoorX.Services.Contracts
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
        /// Gets or sets a value indicating whether if the room has wifi.
        /// </summary>
        bool HasWifi { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether if the resaervation includes a dinner.
        /// </summary>
        bool HasDinner { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        CurrencyType Currency { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether ih the hotel has a pool.
        /// </summary>
        bool HasPool { get; set; }
    }
}