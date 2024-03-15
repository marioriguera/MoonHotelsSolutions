using Microsoft.AspNetCore.Mvc;
using Spedia.Api.Models;
using Spedia.Services.Contracts;

namespace Spedia.Api.Controllers
{
    /// <summary>
    /// Controller for searching hotel rooms.
    /// </summary>
    [ApiController]
    [Route("api/search")]
    public class SearchRoomsController : ControllerBase
    {
        private readonly ISearchRooms _searchRooms;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchRoomsController"/> class.
        /// </summary>
        /// <param name="searchRooms">The search rooms service.</param>
        public SearchRoomsController(ISearchRooms searchRooms)
        {
            _searchRooms = searchRooms ?? throw new ArgumentNullException(nameof(searchRooms));
        }

        /// <summary>
        /// Retrieves a list of available rooms based on the specified search criteria.
        /// </summary>
        /// <param name="roomsRequest">The search criteria.</param>
        /// <returns>A list of available rooms.</returns>
        [HttpPost]
        [Route("rooms")]
        public async Task<ActionResult<SearchRoomsResponse>> GetRoomsAsync([FromBody] SearchRoomsRequest roomsRequest)
        {
            try
            {
                SearchRoomsResponse response = new();
                response.AddNewRooms(await _searchRooms.SearchAsync(roomsRequest));
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest($"Something went wrong: {ex.Message}");
            }
        }
    }
}
