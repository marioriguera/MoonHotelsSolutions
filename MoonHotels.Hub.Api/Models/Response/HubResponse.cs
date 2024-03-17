using MoonHotels.Hub.Services.Contracts;

namespace MoonHotels.Hub.Api.Models.Response
{
    /// <summary>
    /// Represents a response from a hub containing search information.
    /// </summary>
    public class HubResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HubResponse"/> class with the specified search hash code and engine hub.
        /// </summary>
        /// <param name="searchHashCode">The hash code of the search.</param>
        /// <param name="hub">The engine hub containing search information.</param>
        public HubResponse(int searchHashCode, IEngineHub hub)
        {
            SearchHashCode = searchHashCode;
            Hub = hub;
        }

        /// <summary>
        /// Gets or sets the hash code of the search.
        /// </summary>
        public int SearchHashCode { get; set; }

        /// <summary>
        /// Gets or sets the engine hub containing search information.
        /// </summary>
        public IEngineHub Hub { get; set; }
    }
}
