using MoonHotels.Hub.Services.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonHotels.Hub.Services.Models.Suppliers.HotelLegs
{
    internal class HotelLegsRequest : RequestBase
    {
        public HotelLegsRequest(int id)
            : base(id)
        {
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
