using System.Diagnostics;
using MoonHotels.Hub.Services.Contracts;
using MoonHotels.Hub.Services.Models.Base;

namespace MoonHotels.Hub.Services.Models.Suppliers.Spedia
{
    /// <summary>
    /// Represents the response from the Spedia supplier.
    /// </summary>
    internal class SpediaResponse : ResponseBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpediaResponse"/> class with the specified ID and URL.
        /// </summary>
        /// <param name="id">The ID of the response.</param>
        /// <param name="url">The URL of the response.</param>
        public SpediaResponse(int id)
            : base(id, "https://localhost:44318/api/search/rooms")
        {
        }

        /// <summary>
        /// Gets the list of room search results.
        /// </summary>
        public List<SpediaRoomResponse> Results { get; } = new();

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
