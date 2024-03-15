using System.Text.Json.Serialization;
using Spedia.Services.Contracts;

namespace Spedia.Api.Models
{
    /// <summary>
    /// Represents a response containing room information.
    /// </summary>
    public class RoomResponse : IRoom
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoomResponse"/> class with the specified parameters.
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
        /// <param name="hasDinner">If the reservation has dinner.</param>
        public RoomResponse(int room, int meal, bool canCancel, decimal price, int hotel, DateTime checkInDate, int numberOfNights, int rooms, CurrencyType currency, bool hasWifi, bool hasDinner)
        {
            IdentificationOfRoom = room;
            IdentificationOfMeal = meal;
            IfIsPossibleCancel = canCancel;
            CurrentPrice = price;
            Hotel = hotel;
            CheckInDate = checkInDate;
            NumberOfNights = numberOfNights;
            Rooms = rooms;
            Currency = currency;
            HasWifi = hasWifi;
            HasDinner = hasDinner;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomResponse"/> class with the specified parameters.
        /// </summary>
        /// <param name="room">The room object containing information about the room.</param>
        public RoomResponse(IRoom room)
            : this(room.IdentificationOfRoom, room.IdentificationOfMeal, room.IfIsPossibleCancel, room.CurrentPrice, room.Hotel, room.CheckInDate, room.NumberOfNights, room.Rooms, room.Currency, room.HasWifi, room.HasDinner)
        {
        }

        /// <inheritdoc/>
        public int IdentificationOfRoom { get; set; }

        /// <inheritdoc/>
        public int IdentificationOfMeal { get; set; }

        /// <inheritdoc/>
        public bool IfIsPossibleCancel { get; set; }

        /// <inheritdoc/>
        public decimal CurrentPrice { get; set; }

        /// <inheritdoc/>
        [JsonIgnore]
        public int Hotel { get; set; }

        /// <inheritdoc/>
        [JsonIgnore]
        public DateTime CheckInDate { get; set; }

        /// <inheritdoc/>
        [JsonIgnore]
        public int NumberOfNights { get; set; }

        /// <inheritdoc/>
        [JsonIgnore]
        public int Rooms { get; set; }

        /// <inheritdoc/>
        [JsonIgnore]
        public CurrencyType Currency { get; set; }

        /// <inheritdoc/>
        [JsonIgnore]
        public bool HasWifi { get; set; }

        /// <inheritdoc/>
        public bool HasDinner { get; set; }
    }
}
