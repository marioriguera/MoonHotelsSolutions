using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MoonHotels.Hub.Api.Attributes;
using MoonHotels.Hub.Api.Hub;
using MoonHotels.Hub.Api.Models.Request;
using MoonHotels.Hub.Api.Models.Response;

namespace MoonHotels.Hub.Api.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        private readonly IHubContext<MoonHotelsHub> _hubContext;

        public SearchController(IHubContext<MoonHotelsHub> hubContext)
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
        ///       "currency": "EUR"
        ///     }
        ///
        ///     WRONG:
        ///
        ///     {
        ///      "hotelId": 1,
        ///      "checkIn": "1",
        ///      "checkOut": "1",
        ///      "numberOfGuests": -5,
        ///      "numberOfRooms": -43,
        ///      "currency": "otro valor"
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
                await HubComunicationStepsAsync(request);
                return Ok($"The search has started.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong");
            }
        }

        private async Task HubComunicationStepsAsync(EngineHubSearchRequest request)
        {
            await _hubContext.Clients.All.SendAsync("MoonHotelHubSearchResponse", $"Atendiendo la request {request.GetHashCode()}.");

            Rate rate = new(1, true, 1);

            List<Rate> rates = new();
            rates.Add(rate);

            Room room = new(1, rates);
            List<Room> rooms = new();
            rooms.Add(room);

            EngineHubSearchResponse response = new(rooms);

            await _hubContext.Clients.All.SendAsync("MoonHotelHubSearchResponse", response);
            await _hubContext.Clients.All.SendAsync("MoonHotelHubSearchResponse", $"Fin de la request {request.GetHashCode()}.");
        }
    }
}
