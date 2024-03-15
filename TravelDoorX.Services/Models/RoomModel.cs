using TravelDoorX.Services.Contracts;

namespace TravelDoorX.Services.Models
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
        /// <param name="hasWifi">If the room has wifi.</param>
        /// <param name="hasDinner">If the reservation include a dinner.</param>
        /// <param name="hasPool">If the hotel has a pool.</param>
        /// <param name="itsNearToTheBeach">If the hotel its neat to the beach.</param>
        public RoomModel(int room, int meal, bool canCancel, decimal price, int hotel, DateTime checkInDate, int numberOfNights, int rooms, CurrencyType currency, bool hasWifi, bool hasDinner, bool hasPool, bool itsNearToTheBeach)
        {
            IdRoom = room;
            IdMeal = meal;
            IfIsPossibleCancel = canCancel;
            ThePrice = price;
            Hotel = hotel;
            CheckInDate = checkInDate;
            NumberOfNights = numberOfNights;
            Rooms = rooms;
            Currency = currency;
            HasWifiInTheRoom = hasWifi;
            HasDinner = hasDinner;
            HasPool = hasPool;
            ItsNearToTheBeach = itsNearToTheBeach;
        }

        /// <inheritdoc/>
        public int IdRoom { get; set; }

        /// <inheritdoc/>
        public int IdMeal { get; set; }

        /// <inheritdoc/>
        public bool IfIsPossibleCancel { get; set; }

        /// <inheritdoc/>
        public decimal ThePrice { get; set; }

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

        /// <inheritdoc/>
        public bool HasWifiInTheRoom { get; set; }

        /// <inheritdoc/>
        public bool HasDinner { get; set; }

        /// <inheritdoc/>
        public bool HasPool { get; set; }

        /// <inheritdoc/>
        public bool ItsNearToTheBeach { get; set; }
    }
}