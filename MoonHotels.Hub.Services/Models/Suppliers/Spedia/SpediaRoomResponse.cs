using System.Diagnostics;
using MoonHotels.Hub.Services.Contracts;
using MoonHotels.Hub.Services.Models.Base;

namespace MoonHotels.Hub.Services.Models.Suppliers.Spedia
{

    /// <summary>
    /// Represents a response containing room information.
    /// </summary>
    internal class SpediaRoomResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpediaRoomResponse"/> class with the specified parameters.
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
        public SpediaRoomResponse(int room, int meal, bool canCancel, decimal price, int hotel, DateTime checkInDate, int numberOfNights, int rooms, CurrencyType currency, bool hasWifi, bool hasDinner)
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
        /// Gets or sets the room ID.
        /// </summary>
        public int IdentificationOfRoom { get; set; }

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
        public int IdentificationOfMeal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the room reservation can be canceled.
        /// </summary>
        public bool IfIsPossibleCancel { get; set; }

        /// <summary>
        /// Gets or sets the price of the room.
        /// </summary>
        public decimal CurrentPrice { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the number of rooms.
        /// </summary>
        public bool HasWifi { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the number of rooms.
        /// </summary>
        public bool HasDinner { get; set; }

        public Room ConvertToRoom()
        {
            return new Room(IdentificationOfRoom, IdentificationOfMeal, IfIsPossibleCancel, CurrentPrice);
        }
    }
}
