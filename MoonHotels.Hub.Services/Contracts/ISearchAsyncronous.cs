using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonHotels.Hub.Services.Contracts
{
    internal interface ISearchAsyncronous
    {
        ICollection<ISearchSyncronous> SearchAsync(ISearchRoomModel search);
    }
}
