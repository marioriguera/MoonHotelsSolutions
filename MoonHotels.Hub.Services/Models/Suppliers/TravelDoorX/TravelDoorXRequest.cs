using MoonHotels.Hub.Services.Contracts;
using MoonHotels.Hub.Services.Models.Base;
using Newtonsoft.Json;

namespace MoonHotels.Hub.Services.Models.Suppliers.TravelDoorX
{
    /// <summary>
    /// Represents a request for TravelDoorX.
    /// </summary>
    internal class TravelDoorXRequest : RequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TravelDoorXRequest"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">The ID of the search, its the hash code of the hub request.</param>
        /// <param name="hotel">The ID of the hotel.</param>
        /// <param name="checkInDate">The check-in date.</param>
        /// <param name="numberOfNights">The number of nights for the stay.</param>
        /// <param name="guests">The number of guests.</param>
        /// <param name="rooms">The number of rooms.</param>
        /// <param name="currency">The currency type.</param>
        /// <param name="hasWifi">If the room has wifi.</param>
        /// <param name="hasDinner">If the reservation includes a dinner.</param>
        /// <param name="hasPool">If the hotel includes a pool.</param>
        public TravelDoorXRequest(int id, int hotel, DateTime checkInDate, int numberOfNights, int guests, int rooms, CurrencyType currency, bool hasWifi, bool hasDinner, bool hasPool)
            : base(id, "https://localhost:44340/api/search/rooms")
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
        /// Gets or sets the number of guests.
        /// </summary>
        public int Guests { get; set; }

        /// <summary>
        /// Gets or sets the number of rooms.
        /// </summary>
        public int Rooms { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the room has wifi.
        /// </summary>
        public bool HasWifi { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the reservation includes a dinner.
        /// </summary>
        public bool HasDinner { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        public CurrencyType Currency { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the hotel includes a pool.
        /// </summary>
        public bool HasPool { get; set; }

        /// <inheritdoc/>
        public override string ToJson()
        {
            return JsonConvert.SerializeObject(this) ?? string.Empty;
        }

        /// <inheritdoc/>
        public override bool IsValid()
        {
            return true;
        }
    }
}
