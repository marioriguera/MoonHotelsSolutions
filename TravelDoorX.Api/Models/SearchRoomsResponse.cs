using TravelDoorX.Services.Contracts;

namespace TravelDoorX.Api.Models
{
    /// <summary>
    /// Represents a response containing a list of room search results.
    /// </summary>
    public class SearchRoomsResponse
    {
        /// <summary>
        /// Gets the list of room search results.
        /// </summary>
        public List<RoomResponse> Results { get; } = new();

        /// <summary>
        /// Adds new rooms to the search results.
        /// </summary>
        /// <param name="rooms">The list of rooms to add.</param>
        public void AddNewRooms(IEnumerable<IRoom> rooms)
        {
            if (rooms == null || !rooms.Any())
            {
                Results.Clear();
                return;
            }

            Results.Clear();

            foreach (IRoom room in rooms)
            {
                Results.Add(new RoomResponse(room));
            }
        }
    }
}