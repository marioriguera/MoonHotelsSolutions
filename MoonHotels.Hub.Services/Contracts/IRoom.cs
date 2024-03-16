using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonHotels.Hub.Services.Contracts
{
    /// <summary>
    /// Represents an interface for a room.
    /// </summary>
    public interface IRoom
    {
        /// <summary>
        /// Gets or sets the ID of the room.
        /// </summary>
        public int RoomId { get; set; }

        /// <summary>
        /// Gets the list of rates for the room.
        /// </summary>
        public IEnumerable<IRate> Rates { get; }
    }
}
