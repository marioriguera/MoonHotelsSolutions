using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonHotels.Hub.Services.Contracts
{
    /// <summary>
    /// Represents an interface for synchronous search operations.
    /// </summary>
    public interface ISearchSyncronous
    {
        Task<IEngineHub> SearchSync(ISearchRoomModel search);
    }
}
