using MoonHotels.Hub.Services.Contracts;
using MoonHotels.Hub.Services.Models.Base;
using Newtonsoft.Json;

namespace MoonHotels.Hub.Services.Models.Suppliers.HotelLegs
{
    /// <summary>
    /// Represents a request for hotel legs.
    /// </summary>
    internal class HotelLegsRequest : RequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HotelLegsRequest"/> class with the specified parameters.
        /// </summary>
        /// <param name="id">The ID of the search, its the hash code of the hub request.</param>
        /// <param name="hotel">The ID of the hotel.</param>
        /// <param name="checkInDate">The check-in date.</param>
        /// <param name="numberOfNights">The number of nights for the stay.</param>
        /// <param name="guests">The number of guests.</param>
        /// <param name="rooms">The number of rooms.</param>
        /// <param name="currency">The currency type.</param>
        public HotelLegsRequest(int id, int hotel, DateTime checkInDate, int numberOfNights, int guests, int rooms, CurrencyType currency)
            : base(id, "https://localhost:44372/api/search/rooms")
        {
            Hotel = hotel;
            CheckInDate = checkInDate;
            NumberOfNights = numberOfNights;
            Guests = guests;
            Rooms = rooms;
            Currency = currency;
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
        /// Gets or sets the currency.
        /// </summary>
        public CurrencyType Currency { get; set; }

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
