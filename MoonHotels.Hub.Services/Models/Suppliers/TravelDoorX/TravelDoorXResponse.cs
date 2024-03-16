using MoonHotels.Hub.Services.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonHotels.Hub.Services.Models.Suppliers.TravelDoorX
{
    internal class TravelDoorXResponse : ResponseBase
    {
        public TravelDoorXResponse(int id) : base(id, "https://localhost:44340/api/search/rooms")
        {
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
