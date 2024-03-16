using MoonHotels.Hub.Services.Contracts;

namespace MoonHotels.Hub.Services.Business
{
    /// <summary>
    /// Represents a synchronous search operation.
    /// </summary>
    internal class SearchSyncronous : ISearchSyncronous
    {
        /// <inheritdoc/>
        public async Task<ICollection<ISearchSyncronous>> SearchSync(ISearchRoomModel search)
        {
            return null;
        }
    }
}
