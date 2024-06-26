﻿using Spedia.Services.Contracts;
using Spedia.Services.Models;

namespace Spedia.Services.Business
{
    /// <summary>
    /// Service implementation for searching rooms.
    /// </summary>
    internal class SearchRoomsServices : ISearchRooms
    {
        /// <summary>
        /// Rooms field to tests.
        /// </summary>
        private readonly List<RoomModel> _rooms = new()
        {
            new RoomModel(101, 1, true, 110.50m, 1, DateTime.Now, 3, 1, CurrencyType.EUR, true, true),
            new RoomModel(102, 1, false, 120.75m, 1, DateTime.Now, 3, 1, CurrencyType.EUR, true, true),
            new RoomModel(103, 2, true, 140.00m, 1, DateTime.Now, 3, 1, CurrencyType.EUR, true, true),
            new RoomModel(104, 2, true, 135.25m, 1, DateTime.Now, 3, 1, CurrencyType.EUR, true, false),
            new RoomModel(105, 1, false, 115.00m, 1, DateTime.Now, 3, 1, CurrencyType.EUR, true, true),
            new RoomModel(106, 2, true, 130.50m, 1, DateTime.Now, 3, 1, CurrencyType.EUR, true, true),
            new RoomModel(107, 2, false, 145.75m, 1, DateTime.Now, 3, 1, CurrencyType.EUR, true, true),
            new RoomModel(108, 1, true, 135.25m, 1, DateTime.Now, 3, 1, CurrencyType.EUR, true, false),
            new RoomModel(109, 1, false, 125.75m, 1, DateTime.Now, 3, 1, CurrencyType.EUR, true, false),
            new RoomModel(110, 2, true, 150.00m, 1, DateTime.Now, 3, 1, CurrencyType.EUR, true, true),
            new RoomModel(111, 2, true, 130.25m, 1, DateTime.Now, 3, 1, CurrencyType.EUR, true, false),
            new RoomModel(112, 1, false, 130.50m, 1, DateTime.Now, 3, 1, CurrencyType.EUR, true, true),
            new RoomModel(113, 2, true, 115.75m, 1, DateTime.Now, 3, 1, CurrencyType.EUR, true, true),
            new RoomModel(114, 2, false, 155.00m, 1, DateTime.Now, 3, 1, CurrencyType.EUR, true, true),
            new RoomModel(115, 1, true, 160.25m, 1, DateTime.Now, 3, 1, CurrencyType.EUR, true, false),
            new RoomModel(116, 1, false, 145.50m, 1, DateTime.Now, 3, 1, CurrencyType.EUR, true, true),
            new RoomModel(117, 2, true, 135.75m, 1, DateTime.Now, 3, 1, CurrencyType.EUR, true, true),
            new RoomModel(118, 2, true, 170.00m, 1, DateTime.Now, 3, 1, CurrencyType.EUR, true, true),
            new RoomModel(119, 1, false, 180.25m, 1, DateTime.Now, 3, 1, CurrencyType.EUR, true, true),
            new RoomModel(120, 1, true, 155.50m, 1, DateTime.Now, 3, 1, CurrencyType.EUR, true, true),
        };

        /// <inheritdoc/>
        public async Task<IEnumerable<IRoom>> SearchAsync(ISearchRoomModel searchModel)
        {
            await Task.Delay(1);

            List<RoomModel> results = _rooms.Where(room => searchModel.Hotel.Equals(room.Hotel) &&
                                                           searchModel.Currency.Equals(room.Currency) &&
                                                           searchModel.CheckInDate <= room.CheckInDate &&
                                                           searchModel.HasDinner.Equals(room.HasDinner) &&
                                                           searchModel.HasWifi.Equals(room.HasWifi))
                                                           .ToList();
            return results.Count >= searchModel.Rooms ? results : Enumerable.Empty<IRoom>();
        }
    }
}
