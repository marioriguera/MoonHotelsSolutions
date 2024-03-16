using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonHotels.Hub.Services.Contracts
{/// <summary>
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
    /// Sear room model contract.
    /// </summary>
    public interface ISearchRoomModel
    {
        /// <summary>
        /// Gets id search. Its the hash code of the hub request.
        /// </summary>
        int IdSearch { get; }

        /// <summary>
        /// Gets the ID of the hotel.
        /// </summary>
        int HotelId { get; }

        /// <summary>
        /// Gets the check-in date.
        /// </summary>
        DateTime CheckIn { get; }

        /// <summary>
        /// Gets the check-out date.
        /// </summary>
        DateTime CheckOut { get; }

        /// <summary>
        /// Gets the number of guests.
        /// </summary>
        int NumberOfGuests { get; }

        /// <summary>
        /// Gets the number of rooms.
        /// </summary>
        int NumberOfRooms { get; }

        /// <summary>
        /// Gets the currency.
        /// </summary>
        CurrencyType Currency { get; }
    }
}
