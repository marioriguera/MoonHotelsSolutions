using System.Diagnostics;
using MoonHotels.Hub.Services.Contracts;
using MoonHotels.Hub.Services.Models.Base;

namespace MoonHotels.Hub.Services.Models.Suppliers.TravelDoorX
{
    /// <summary>
    /// Represents the response from the TravelDoorX supplier.
    /// </summary>
    internal class TravelDoorXResponse : ResponseBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TravelDoorXResponse"/> class with the specified ID and URL.
        /// </summary>
        /// <param name="id">The ID of the response.</param>
        public TravelDoorXResponse(int id)
            : base(id, "https://localhost:44340/api/search/rooms")
        {
        }

        /// <summary>
        /// Gets the list of room search results.
        /// </summary>
        public List<TravelDoorXoomResponse> Results { get; } = new();

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

            return new(groupedRooms);
        }
    }
}
