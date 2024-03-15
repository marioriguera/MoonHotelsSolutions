using HotelLegs.Services.Contracts;
using HotelLegs.Services.Models;

namespace HotelLegs.Services.Business
{
    internal class SearchRoomsServices : ISearchRooms
    {
        public List<IRooms> Search(Func<ISearchRoomModel> function)
        {
            throw new NotImplementedException();
        }
    }
}
