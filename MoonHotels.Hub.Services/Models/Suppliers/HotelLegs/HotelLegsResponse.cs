﻿using MoonHotels.Hub.Services.Contracts;
using MoonHotels.Hub.Services.Models.Base;
using System.Linq;

namespace MoonHotels.Hub.Services.Models.Suppliers.HotelLegs
{
    /// <summary>
    /// Represents the response from the Hotel Legs supplier.
    /// </summary>
    internal class HotelLegsResponse : ResponseBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HotelLegsResponse"/> class with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the response.</param>
        public HotelLegsResponse(int id)
            : base(id, "https://localhost:44372/api/search/rooms")
        {
        }

        /// <summary>
        /// Gets the list of room search results.
        /// </summary>
        public List<HotelLegsRoomResponse> Results { get; } = new();

        /// <inheritdoc/>
        public override bool IsValid()
        {
            return true;
        }

        public override EngineHub ToEngineHub()
        {
            var groupedRooms = Results.Select(x => x.ConvertToRoom()).ToList()
                               .GroupBy(room => room.RoomId)
                               .Select(group => new Room(group.Key, group.SelectMany(room => room.Rates).ToList()))
                               .ToList();

            return new(groupedRooms);
        }
    }

    /// <summary>
    /// Represents a response containing room information.
    /// </summary>
    internal class HotelLegsRoomResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HotelLegsRoomResponse"/> class with the specified parameters.
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
        public HotelLegsRoomResponse(int room, int meal, bool canCancel, decimal price, int hotel, DateTime checkInDate, int numberOfNights, int rooms, CurrencyType currency)
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

        /// <summary>
        /// Gets or sets the room ID.
        /// </summary>
        public int Room { get; set; }

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
        public int Meal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the room reservation can be canceled.
        /// </summary>
        public bool CanCancel { get; set; }

        /// <summary>
        /// Gets or sets the price of the room.
        /// </summary>
        public decimal Price { get; set; }

        public Room ConvertToRoom()
        {
            return new Room(Room, Meal, CanCancel, Price);
        }
    }
}
