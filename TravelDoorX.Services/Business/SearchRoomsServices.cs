using TravelDoorX.Services.Contracts;
using TravelDoorX.Services.Models;

namespace TravelDoorX.Services.Business
{
    internal class SearchRoomsServices : ISearchRooms
    {
        public List<RoomsDto> Search(Func<ISearchRoomModel> function)
        {
            throw new NotImplementedException();
        }
    }
}
