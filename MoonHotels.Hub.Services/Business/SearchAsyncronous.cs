using MoonHotels.Hub.Services.Contracts;
using MoonHotels.Hub.Services.Models;

namespace MoonHotels.Hub.Services.Business
{
    /// <summary>
    /// Represents an asynchronous search operation.
    /// </summary>
    internal class SearchAsyncronous : ISearchAsyncronous
    {
        /// <summary>
        /// Asynchronously searches for engine hubs based on the provided search model.
        /// </summary>
        /// <param name="search">The search model containing the criteria for the search.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of engine hubs.</returns>
        public async Task<ICollection<IEngineHub>> SearchAsync(ISearchRoomModel search)
        {
            List<EngineHub> engineHubs = new();
            return (ICollection<IEngineHub>)engineHubs;
        }
    }
}
