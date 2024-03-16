using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonHotels.Hub.Services.Models.Base
{
    internal abstract class Base
    {
        protected Base(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public abstract bool IsValid();
    }
}
