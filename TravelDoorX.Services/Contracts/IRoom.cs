namespace TravelDoorX.Services.Contracts
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
    /// Represents a room entity.
    /// </summary>
    public interface IRoom
    {
        /// <summary>
        /// Gets or sets the room ID.
        /// </summary>
        public int IdRoom { get; set; }

        /// <summary>
        /// Gets or sets the ID of the hotel.
        /// </summary>
        public int Hotel { get; set; }

        /// <summary>
        /// Gets or sets the check-in date.
        /// </summary>
        public DateTime CheckInDate { get; set; }

        /// <summary>
        /// Gets or sets the number of nights for the stay.
        /// </summary>
        public int NumberOfNights { get; set; }

        /// <summary>
        /// Gets or sets the number of rooms.
        /// </summary>
        public int Rooms { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        public CurrencyType Currency { get; set; }

        /// <summary>
        /// Gets or sets the meal option.
        /// </summary>
        public int IdMeal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the room reservation can be canceled.
        /// </summary>
        public bool IfIsPossibleCancel { get; set; }

        /// <summary>
        /// Gets or sets the price of the room.
        /// </summary>
        public decimal ThePrice { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether has a wifi.
        /// </summary>
        bool HasWifiInTheRoom { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether has a dinner.
        /// </summary>
        bool HasDinner { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether has a pool.
        /// </summary>
        bool HasPool { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether if near of the beach.
        /// </summary>
        bool ItsNearToTheBeach { get; set; }
    }
}