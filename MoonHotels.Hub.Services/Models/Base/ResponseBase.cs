using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonHotels.Hub.Services.Models.Base
{
    internal abstract class ResponseBase : Base
    {
        public ResponseBase(int id, string url) : base(id, url) { }

        public abstract EngineHub ToEngineHub();
    }
}
