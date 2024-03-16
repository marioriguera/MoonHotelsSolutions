﻿using MoonHotels.Hub.Services.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonHotels.Hub.Services.Models.Suppliers.HotelLegs
{
    internal class HotelLegsResponse : ResponseBase
    {
        public HotelLegsResponse(int id) : base(id, "https://localhost:44372/api/search/rooms")
        {
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
