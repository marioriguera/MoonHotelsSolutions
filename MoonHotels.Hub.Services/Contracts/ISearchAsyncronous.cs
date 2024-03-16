using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonHotels.Hub.Services.Contracts
{
    /// <summary>
    /// Represents an interface for asynchronous search operations.
    /// </summary>
    public interface ISearchAsyncronous
    {
        /// <summary>
        /// Asynchronously searches for engine hubs based on the provided search model.
        /// </summary>
        /// <param name="search">The search model containing the criteria for the search.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of engine hubs.</returns>
        Task<ICollection<IEngineHub>> SearchAsync(ISearchRoomModel search);
    }
}
