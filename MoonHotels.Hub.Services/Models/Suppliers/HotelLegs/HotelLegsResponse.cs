using System.Linq;
using MoonHotels.Hub.Services.Contracts;
using MoonHotels.Hub.Services.Models.Base;

namespace MoonHotels.Hub.Services.Models.Suppliers.HotelLegs
{
    /// <summary>
    /// Represents the response from the Hotel Legs supplier.
    /// </summary>
    internal class HotelLegsResponse : ResponseBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HotelLegsResponse"/> class with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the response.</param>
        public HotelLegsResponse(int id)
            : base(id, "https://localhost:44372/api/search/rooms")
        {
        }

        /// <summary>
        /// Gets the list of room search results.
        /// </summary>
        public List<HotelLegsRoomResponse> Results { get; } = new();

        /// <inheritdoc/>
        public override bool IsValid()
        {
            return true;
        }

        /// <inheritdoc/>
        public override EngineHub ToEngineHub()
        {
            var groupedRooms = Results.Select(x => x.ConvertToRoom()).ToList()
                               .GroupBy(room => room.RoomId)
                               .Select(group => new Room(group.Key, group.SelectMany(room => room.Rates).ToList()))
                               .ToList();

            return new EngineHub(groupedRooms);
        }
    }
}
