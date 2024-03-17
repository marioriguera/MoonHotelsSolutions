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
        /// Synchronously searches for available rooms based on the specified search criteria and logs any exceptions.
        /// </summary>
        /// <param name="search">The search criteria.</param>
        /// <param name="logger">The logger instance for logging exceptions.</param>
        /// <returns>An asynchronous operation returning the search results as an engine hub.</returns>
        Task<IEngineHub> SearchSync(ISearchRoomModel search, NLog.ILogger logger);
    }
}
