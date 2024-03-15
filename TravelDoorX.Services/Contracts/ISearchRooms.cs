﻿using TravelDoorX.Services.Models;

namespace TravelDoorX.Services.Contracts
{
    /// <summary>
    /// Interface for searching rooms.
    /// </summary>
    public interface ISearchRooms
    {
        /// <summary>
        /// Searches for rooms based on the specified search criteria.
        /// </summary>
        /// <param name="func">A function that creates the search room model.</param>
        /// <returns>A list of rooms DTOs matching the search criteria.</returns>
        List<RoomsDto> Search(Func<ISearchRoomModel> func);
    }
}
