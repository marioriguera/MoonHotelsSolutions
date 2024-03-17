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
    [Route("api/sync-search")]
    public class SyncronousSearchController : ControllerBase
    {
        private readonly ISearchSyncronous _searchSyncronous;

        /// <summary>
        /// Initializes a new instance of the <see cref="SyncronousSearchController"/> class.
        /// </summary>
        /// <param name="searchSyncronous">The synchronous search service.</param>
        public SyncronousSearchController(ISearchSyncronous searchSyncronous)
        {
            _searchSyncronous = searchSyncronous;
        }

        /// <summary>
        /// Starts a search process using the engine hub based on the provided search request.
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
        public async Task<ActionResult<EngineHubSearchResponse>> StartSearch([FromBody] EngineHubSearchRequest request)
        {
            try
            {
                return Ok(await _searchSyncronous.SearchSync(request, ApiConfigurationService.Current.Logger));
            }
            catch (Exception ex)
            {
                ApiConfigurationService.Current.Logger.Fatal(ex, $"Unhandle exceptions has ocurred in {nameof(StartSearch)}. Message {ex.Message} .");
                return BadRequest($"Something went wrong");
            }
        }
    }
}
