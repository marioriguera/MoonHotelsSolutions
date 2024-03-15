using System.Linq.Expressions;
using HotelLegs.Services.Models;

namespace HotelLegs.Services.Contracts
{
    /// <summary>
    /// Interface for searching rooms.
    /// </summary>
    public interface ISearchRooms
    {
        /// <summary>
        /// Searches for rooms based on the specified search model.
        /// </summary>
        /// <param name="searchModel">The search model containing the criteria.</param>
        /// <returns>A list of rooms matching the search criteria.</returns>
        Task<IEnumerable<IRoom>> SearchAsync(ISearchRoomModel searchModel);
    }
}
