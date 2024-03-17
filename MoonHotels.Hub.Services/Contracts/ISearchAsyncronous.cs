namespace MoonHotels.Hub.Services.Contracts
{
    /// <summary>
    /// Represents an interface for asynchronous search operations.
    /// </summary>
    public interface ISearchAsyncronous
    {
        /// <summary>
        /// Asynchronously searches for rooms based on the provided search criteria.
        /// </summary>
        /// <param name="search">The search criteria.</param>
        /// <param name="callbackStartSearch">Callback action invoked when the search begins.</param>
        /// <param name="callbackMessages">Callback action invoked when messages are received during the search.</param>
        /// <param name="callbackFinishSearch">Callback action invoked when the search finishes.</param>
        /// <param name="logger">Logger for logging messages.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task SearchAsync(ISearchRoomModel search, Action<int> callbackStartSearch,
                            Action<IEngineHub, int> callbackMessages, Action<int> callbackFinishSearch, NLog.ILogger logger);
    }
}
