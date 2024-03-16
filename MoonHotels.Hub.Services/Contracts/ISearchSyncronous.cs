using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonHotels.Hub.Services.Contracts
{
    /// <summary>
    /// Represents an interface for synchronous search operations.
    /// </summary>
    public interface ISearchSyncronous
    {
        /// <summary>
        /// Synchronously searches for engine hubs based on the provided search model.
        /// </summary>
        /// <param name="search">The search model containing the criteria for the search.</param>
        /// <returns>A collection of engine hubs.</returns>
        Task<ICollection<ISearchSyncronous>> SearchSync(ISearchRoomModel search);
    }
}
