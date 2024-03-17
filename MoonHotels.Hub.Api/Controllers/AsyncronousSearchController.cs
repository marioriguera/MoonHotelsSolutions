using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MoonHotels.Hub.Api.Attributes;
using MoonHotels.Hub.Api.Config;
using MoonHotels.Hub.Api.Hub;
using MoonHotels.Hub.Api.Models.Request;
using MoonHotels.Hub.Api.Models.Response;
using MoonHotels.Hub.Services.Contracts;

namespace MoonHotels.Hub.Api.Controllers
{
    /// <summary>
    /// Controller for handling search requests.
    /// </summary>
    [ApiController]
    [Route("api/async-search")]
    public class AsyncronousSearchController : ControllerBase
    {
        private readonly IHubContext<MoonHotelsHub> _hubContext;
        private readonly ISearchAsyncronous _searchAsyncronous;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncronousSearchController"/> class.
        /// </summary>
        /// <param name="hubContext">The hub context.</param>
        /// <param name="searchAsyncronous">The asynchronous search service.</param>
        public AsyncronousSearchController(IHubContext<MoonHotelsHub> hubContext, ISearchAsyncronous searchAsyncronous)
        {
            _hubContext = hubContext;
            _searchAsyncronous = searchAsyncronous;
        }

        /// <summary>
        /// Starts an asyncronous search process using the engine hub based on the provided search request.
        /// </summary>
        /// <param name="request">The search request containing parameters for the search.</param>
        /// <returns>An asynchronous task representing the HTTP action result with a message indicating the search has started.</returns>
        /// <remarks>
        /// Example requests:
        ///
        ///     GOOD:
        ///
        ///     {
        ///       "hotelId": 1,
        ///       "checkIn": "2024-03-12",
        ///       "checkOut": "2024-03-15",
        ///       "numberOfGuests": 5,
        ///       "numberOfRooms": 3,
        ///       "currency": 1
        ///     }
        ///
        ///     WRONG:
        ///
        ///     {
        ///      "hotelId": -10,
        ///      "checkIn": "1",
        ///      "checkOut": "1",
        ///      "numberOfGuests": -5,
        ///      "numberOfRooms": -43,
        ///      "currency": 20
        ///     }.
        ///
        /// </remarks>
        [HttpPost]
        [Route("start")]
        [ValidateSearchRequest]
        public async Task<ActionResult<string>> StartSearch([FromBody] EngineHubSearchRequest request)
        {
            try
            {
                await _searchAsyncronous.SearchAsync(request, StartSearch, SendHub, FinishSearch, ApiConfigurationService.Current.Logger);
                return Ok($"The search {request.GetHashCode()} has started.");
            }
            catch (Exception ex)
            {
                ApiConfigurationService.Current.Logger.Fatal(ex, $"Unhandle exceptions has ocurred in {nameof(StartSearch)}.");
                return BadRequest($"Something went wrong");
            }
        }

        /// <summary>
        /// Sends a signal to start the search with the specified search hash code.
        /// </summary>
        /// <param name="searchHashCode">The hash code of the search.</param>
        private async void StartSearch(int searchHashCode)
        {
            await _hubContext.Clients.All.SendAsync("MoonHotelHubSearchResponse", $"Start {searchHashCode}.");
        }

        /// <summary>
        /// Sends a signal to finish the search with the specified search hash code.
        /// </summary>
        /// <param name="searchHashCode">The hash code of the search.</param>
        private async void FinishSearch(int searchHashCode)
        {
            await _hubContext.Clients.All.SendAsync("MoonHotelHubSearchResponse", $"End {searchHashCode}.");
        }

        /// <summary>
        /// Sends the engine hub information to the clients.
        /// </summary>
        /// <param name="hub">The engine hub containing search information.</param>
        /// <param name="searchHashCode">The hash code of the search.</param>
        private async void SendHub(IEngineHub hub, int searchHashCode)
        {
            await _hubContext.Clients.All.SendAsync("MoonHotelHubSearchResponse", new HubResponse(searchHashCode, hub));
        }
    }
}
