using MoonHotels.Hub.Services.Contracts;
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

        /// <inheritdoc/>
        public async Task<ICollection<ISearchSyncronous>> SearchSync(ISearchRoomModel search)
        {
            // Step 1: update requests to use in http requests.
            UpdateRequests(search);

            // Step 2: update api clients list.
            UpdateApiClients(search);

            // Step 3: do requests.
            await DoRequestsAsync();

            return null;
        }

        private async Task DoRequestsAsync()
        {
            IEnumerable<Task> tasks = apiClients.Select(apiClient => apiClient.PostDataAsync());

            // Esperar a que todas las tareas se completen utilizando Task.WhenAll
            try
            {
                await Task.WhenAll(tasks);
                Console.WriteLine("All requests completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void UpdateApiClients(ISearchRoomModel search)
        {
            apiClients.Clear();

            foreach (RequestBase request in requests)
            {
                if (request is HotelLegsRequest)
                {
                    apiClients.Add(new(request.Url, ((HotelLegsRequest)request).ToJson()));
                    continue;
                }

                if (request is SpediaRequest)
                {
                    apiClients.Add(new(request.Url, ((SpediaRequest)request).ToJson()));
                    continue;
                }

                if (request is TravelDoorXRequest)
                {
                    apiClients.Add(new(request.Url, ((TravelDoorXRequest)request).ToJson()));
                    continue;
                }

            }
        }

        private void UpdateRequests(ISearchRoomModel search)
        {
            requests.Clear();

            // To Hotel Legs supplier.
            HotelLegsRequest hotelLegsRequest = new(search.IdSearch, search.HotelId, search.CheckIn, DEFAULTNUMBEROFNIGHTS, search.NumberOfGuests, search.NumberOfRooms, search.Currency);
            requests.Add(hotelLegsRequest);

            // To Hotel Legs supplier.
            SpediaRequest spediaRequest = new(search.IdSearch, search.HotelId, search.CheckIn, DEFAULTNUMBEROFNIGHTS, search.NumberOfGuests, search.NumberOfRooms, search.Currency, DEFAULTHASWIFI, DEFAULTHASPOOL);
            requests.Add(spediaRequest);

            // To Hotel Legs supplier.
            TravelDoorXRequest travelDoorXRequest = new(search.IdSearch, search.HotelId, search.CheckIn, DEFAULTNUMBEROFNIGHTS, search.NumberOfGuests, search.NumberOfRooms, search.Currency, DEFAULTHASWIFI, DEFAULTHASDINNER, DEFAULTHASPOOL);
            requests.Add(spediaRequest);
        }
    }
}
