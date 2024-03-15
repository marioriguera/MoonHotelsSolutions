using HotelLegs.Services.Contracts;

namespace HotelLegs.Services.Models
{
    /// <summary>
    /// Represents a room entity.
    /// </summary>
    public class RoomModel : IRoom
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomModel"/> class with the specified parameters.
        /// </summary>
        /// <param name="room">The room number.</param>
        /// <param name="meal">The meal option.</param>
        /// <param name="canCancel">A value indicating whether the room reservation can be canceled.</param>
        /// <param name="price">The price of the room.</param>
        /// <param name="hotel">The ID of the hotel.</param>
        /// <param name="checkInDate">The check-in date.</param>
        /// <param name="numberOfNights">The number of nights for the stay.</param>
        /// <param name="rooms">The number of rooms.</param>
        /// <param name="currency">The currency type.</param>
        public RoomModel(int room, int meal, bool canCancel, decimal price, int hotel, DateTime checkInDate, int numberOfNights, int rooms, CurrencyType currency)
        {
            Room = room;
            Meal = meal;
            CanCancel = canCancel;
            Price = price;
            Hotel = hotel;
            CheckInDate = checkInDate;
            NumberOfNights = numberOfNights;
            Rooms = rooms;
            Currency = currency;
        }

        /// <inheritdoc/>
        public int Room { get; set; }

        /// <inheritdoc/>
        public int Meal { get; set; }

        /// <inheritdoc/>
        public bool CanCancel { get; set; }

        /// <inheritdoc/>
        public decimal Price { get; set; }

        /// <inheritdoc/>
        public int Hotel { get; set; }

        /// <inheritdoc/>
        public DateTime CheckInDate { get; set; }

        /// <inheritdoc/>
        public int NumberOfNights { get; set; }

        /// <inheritdoc/>
        public int Rooms { get; set; }

        /// <inheritdoc/>
        public CurrencyType Currency { get; set; }
    }
}