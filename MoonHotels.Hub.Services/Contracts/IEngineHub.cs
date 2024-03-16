using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonHotels.Hub.Services.Contracts
{
    /// <summary>
    /// Represents an interface for the engine hub.
    /// </summary>
    public interface IEngineHub
    {
        /// <summary>
        /// Gets the list of rooms in the response.
        /// </summary>
        public IEnumerable<IRoom> Rooms { get; }
    }
}
