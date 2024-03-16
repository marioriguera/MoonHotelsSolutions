using MoonHotels.Hub.Services.Contracts;
using MoonHotels.Hub.Services.Models;
using MoonHotels.Hub.Services.Models.Base;
using MoonHotels.Hub.Services.Models.Comunication;
using MoonHotels.Hub.Services.Models.Suppliers.HotelLegs;
using MoonHotels.Hub.Services.Models.Suppliers.Spedia;
using MoonHotels.Hub.Services.Models.Suppliers.TravelDoorX;

namespace MoonHotels.Hub.Services.Business
{
    /// <summary>
    /// Represents a synchronous search operation.
    /// </summary>
    internal class SearchSyncronous : ISearchSyncronous
    {
        private const int DEFAULTNUMBEROFNIGHTS = 3;
        private const bool DEFAULTHASWIFI = true;
        private const bool DEFAULTHASPOOL = true;
        private const bool DEFAULTHASDINNER = true;
        private readonly List<ApiClient> apiClients = new();
        private readonly List<RequestBase> requests = new();
        private readonly List<ResponseBase> responses = new();

        /// <inheritdoc/>
        public async Task<IEngineHub> SearchSync(ISearchRoomModel search)
        {
            // Step 1: update requests to use in http requests.
            UpdateRequests(search);

            // Step 2: update api clients list.
            UpdateApiClients(search);

            // Step 3: do requests.
            await DoRequestsAsync();

            // Step 4: take responses
            UpdateResponses();

            // Step 5: group and return hubs.
            return GroupAllEngineHubs();
        }

        private EngineHub GroupAllEngineHubs()
        {
            var hubs = responses.SelectMany(resp => resp.ToEngineHub().Rooms).ToList();
            var groupedRooms = hubs.GroupBy(room => room.RoomId)
                                           .Select(group => new Room(group.Key, group.SelectMany(room => room.Rates).ToList()))
                                           .ToList();
            return new(groupedRooms);
        }

        /// <summary>
        /// Updates the responses based on the deserialized responses from each <see cref="ApiClient"/>.
        /// </summary>
        private void UpdateResponses()
        {
            responses.Clear();

            foreach (ApiClient apiClient in apiClients)
            {
                if (apiClient.ApiUrl.Equals(new HotelLegsResponse(-1).Url, StringComparison.Ordinal))
                {
                    responses.Add(apiClient.DeserializeResponse<HotelLegsResponse>());
                    continue;
                }

                if (apiClient.ApiUrl.Equals(new SpediaResponse(-1).Url, StringComparison.Ordinal))
                {
                    responses.Add(apiClient.DeserializeResponse<SpediaResponse>());
                    continue;
                }

                if (apiClient.ApiUrl.Equals(new TravelDoorXResponse(-1).Url, StringComparison.Ordinal))
                {
                    responses.Add(apiClient.DeserializeResponse<TravelDoorXResponse>());
                    continue;
                }
            }
        }

        /// <summary>
        /// Performs asynchronous requests to all API clients.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task DoRequestsAsync()
        {
            // Wait for all tasks to complete using Task.WhenAll
            try
            {
                await Task.WhenAll(apiClients.Select(apiClient => apiClient.PostDataAsync()));
                Console.WriteLine("All requests completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
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
