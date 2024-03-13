using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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

        [HttpPost]
        [Route("start")]
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
