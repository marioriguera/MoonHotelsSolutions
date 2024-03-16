using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonHotels.Hub.Services.Models.Base
{
    internal abstract class RequestBase : Base
    {
        protected RequestBase(int id) : base(id) { }
    }
}
