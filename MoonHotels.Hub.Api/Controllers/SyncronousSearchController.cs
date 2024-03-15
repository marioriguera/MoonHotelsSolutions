using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MoonHotels.Hub.Api.Attributes;
using MoonHotels.Hub.Api.Config;
using MoonHotels.Hub.Api.Hub;
using MoonHotels.Hub.Api.Models.Request;
using MoonHotels.Hub.Api.Models.Response;

namespace MoonHotels.Hub.Api.Controllers
{
    /// <summary>
    /// Controller for handling search requests.
    /// </summary>
    [ApiController]
    [Route("api/sync-search")]
    public class SyncronousSearchController : ControllerBase
    {
        private readonly IHubContext<MoonHotelsHub> _hubContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="SyncronousSearchController"/> class.
        /// </summary>
        /// <param name="hubContext">The hub context for MoonHotels communication.</param>
        public SyncronousSearchController(IHubContext<MoonHotelsHub> hubContext)
        {
            _hubContext = hubContext;
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
        public async Task<ActionResult<string>> StartSearch([FromBody] EngineHubSearchRequest request)
        {
            try
            {
                return Ok($"The search {request.GetHashCode()} has started.");
            }
            catch (Exception ex)
            {
                ApiConfigurationService.Current.Logger.Fatal(ex, $"Unhandle exceptions has ocurred in {nameof(StartSearch)}.");
                return BadRequest($"Something went wrong");
            }
        }
    }
}
