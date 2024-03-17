using System.Diagnostics;
using MoonHotels.Hub.Services.Contracts;
using MoonHotels.Hub.Services.Models.Base;

namespace MoonHotels.Hub.Services.Models.Suppliers.TravelDoorX
{

    /// <summary>
    /// Represents a response containing room information.
    /// </summary>
    internal class TravelDoorXoomResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TravelDoorXoomResponse"/> class with the specified parameters.
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
        /// <param name="hasPool">If the hotel has a pool.</param>
        /// <param name="itsNearToTheBeach">If the hotel its near to the beach.</param>
        public TravelDoorXoomResponse(int room, int meal, bool canCancel, decimal price, int hotel, DateTime checkInDate, int numberOfNights, int rooms, CurrencyType currency,
                            bool hasWifi, bool hasDinner, bool hasPool, bool itsNearToTheBeach)
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
        public bool HasWifiInTheRoom { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether has a dinner.
        /// </summary>
        public bool HasDinner { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether has a pool.
        /// </summary>
        public bool HasPool { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether if near of the beach.
        /// </summary>
        public bool ItsNearToTheBeach { get; set; }

        public Room ConvertToRoom()
        {
            return new Room(IdRoom, IdMeal, IfIsPossibleCancel, ThePrice);
        }
    }
}
