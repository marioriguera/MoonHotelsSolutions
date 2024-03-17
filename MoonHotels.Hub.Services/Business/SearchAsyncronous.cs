using MoonHotels.Hub.Services.Contracts;
using MoonHotels.Hub.Services.Models.Base;
using MoonHotels.Hub.Services.Models.Comunication;
using MoonHotels.Hub.Services.Models.Suppliers.HotelLegs;
using MoonHotels.Hub.Services.Models.Suppliers.Spedia;
using MoonHotels.Hub.Services.Models.Suppliers.TravelDoorX;
using NLog;

namespace MoonHotels.Hub.Services.Business
{
    /// <summary>
    /// Represents an asynchronous search operation.
    /// </summary>
    internal class SearchAsyncronous : ISearchAsyncronous
    {
        private const int DEFAULTNUMBEROFNIGHTS = 3;
        private const bool DEFAULTHASWIFI = true;
        private const bool DEFAULTHASPOOL = true;
        private const bool DEFAULTHASDINNER = true;
        private readonly List<ApiClient> apiClients = new();
        private readonly List<RequestBase> requests = new();

        /// <inheritdoc/>
        public Task SearchAsync(ISearchRoomModel search, Action<int> callbackStartSearch, Action<IEngineHub, int> callbackMessages, Action<int> callbackFinishSearch, ILogger logger)
        {
            // Step 1: update requests to use in http requests.
            UpdateRequests(search);

            // Step 2: update api clients list.
            UpdateApiClients(search);

            // Step 3: do requests.
            _ = DoRequestsAsync(logger, search.GetHashCode(), callbackStartSearch, callbackMessages, callbackFinishSearch);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Asynchronously performs the requests and invokes the provided callbacks.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="searchHashCode">The hash code of the search.</param>
        /// <param name="callbackStartSearch">The callback invoked when the search starts.</param>
        /// <param name="callbackMessages">The callback invoked when messages are received.</param>
        /// <param name="callbackFinishSearch">The callback invoked when the search finishes.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task DoRequestsAsync(NLog.ILogger logger, int searchHashCode, Action<int> callbackStartSearch, Action<IEngineHub, int> callbackMessages, Action<int> callbackFinishSearch)
        {
            // Invoke the callback for search start
            callbackStartSearch(searchHashCode);

            // Create a Barrier with the number of participants equal to the number of tasks
            using (var barrier = new Barrier(apiClients.Count))
            {
                // Create a CancellationTokenSource with a cancellation token of 10 seconds
                using (var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10)))
                {
                    var cancellationToken = cancellationTokenSource.Token;

                    // Start each task
                    var tasks = apiClients.ConvertAll(apiClient => Task.Run(
                        async () =>
                        {
                            try
                            {
                                // Execute the task and pass the result to the messages callback
                                await apiClient.PostDataAsync(logger);

                                var hub = apiClient.GetResponse().ToEngineHub();

                                callbackMessages(hub, searchHashCode);
                            }
                            catch (Exception ex)
                            {
                                // Log any exception that occurs in the task
                                logger.Error(ex, $"Error occurred while processing request for searchHashCode: {searchHashCode}");
                            }
                            finally
                            {
                                // Notify the barrier that this task has finished
                                barrier.SignalAndWait(cancellationToken);
                            }
                        }, cancellationToken));

                    // Wait until all tasks have finished or cancellation time is reached
                    await Task.WhenAll((IEnumerable<Task>)tasks);
                }
            }

            callbackFinishSearch(searchHashCode);
        }

        /// <summary>
        /// Updates the API clients based on the specified <paramref name="search"/> criteria.
        /// </summary>
        /// <param name="search">The search criteria.</param>
        private void UpdateApiClients(ISearchRoomModel search)
        {
            apiClients.Clear();

            foreach (RequestBase request in requests)
            {
                if (request is HotelLegsRequest hotelLegsRequest)
                {
                    apiClients.Add(new ApiClient(request.Url, hotelLegsRequest.ToJson()));
                    continue;
                }

                if (request is SpediaRequest spediaRequest)
                {
                    apiClients.Add(new ApiClient(request.Url, spediaRequest.ToJson()));
                    continue;
                }

                if (request is TravelDoorXRequest travelDoorXRequest)
                {
                    apiClients.Add(new ApiClient(request.Url, travelDoorXRequest.ToJson()));
                    continue;
                }
            }
        }

        /// <summary>
        /// Updates the requests based on the specified <paramref name="search"/> criteria.
        /// </summary>
        /// <param name="search">The search criteria.</param>
        private void UpdateRequests(ISearchRoomModel search)
        {
            requests.Clear();

            // To Hotel Legs supplier.
            HotelLegsRequest hotelLegsRequest = new HotelLegsRequest(search.IdSearch, search.HotelId, search.CheckIn, DEFAULTNUMBEROFNIGHTS, search.NumberOfGuests, search.NumberOfRooms, search.Currency);
            requests.Add(hotelLegsRequest);

            // To Spedia supplier.
            SpediaRequest spediaRequest = new SpediaRequest(search.IdSearch, search.HotelId, search.CheckIn, DEFAULTNUMBEROFNIGHTS, search.NumberOfGuests, search.NumberOfRooms, search.Currency, DEFAULTHASWIFI, DEFAULTHASPOOL);
            requests.Add(spediaRequest);

            // To TravelDoorX supplier.
            TravelDoorXRequest travelDoorXRequest = new TravelDoorXRequest(search.IdSearch, search.HotelId, search.CheckIn, DEFAULTNUMBEROFNIGHTS, search.NumberOfGuests, search.NumberOfRooms, search.Currency, DEFAULTHASWIFI, DEFAULTHASDINNER, DEFAULTHASPOOL);
            requests.Add(travelDoorXRequest);
        }
    }
}
