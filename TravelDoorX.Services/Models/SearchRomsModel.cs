using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelDoorX.Services.Contracts;

namespace TravelDoorX.Services.Models
{
    /// <summary>
    /// Represents the model for searching rooms.
    /// </summary>
    internal class SearchRomsModel : ISearchRoomModel
    {
        /// <inheritdoc/>
        public int Hotel { get; set; }

        /// <inheritdoc/>
        public DateTime CheckInDate { get; set; }

        /// <inheritdoc/>
        public int NumberOfNights { get; set; }

        /// <inheritdoc/>
        public int Guests { get; set; }

        /// <inheritdoc/>
        public int Rooms { get; set; }

        /// <inheritdoc/>
        public int Currency { get; set; }
    }
}
