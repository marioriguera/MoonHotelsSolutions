using Spedia.Services.Contracts;
using Spedia.Services.Models;

namespace Spedia.Services.Business
{
    internal class SearchRoomsServices : ISearchRooms
    {
        public List<RoomsDto> Search(Func<ISearchRoomModel> function)
        {
            throw new NotImplementedException();
        }
    }
}
