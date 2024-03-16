namespace MoonHotels.Hub.Services.Models.Base
{
    internal abstract class RequestBase : Base
    {
        protected RequestBase(int id, string url)
            : base(id, url)
        {
        }

        /// <summary>
        /// Converts the object to a JSON string.
        /// </summary>
        /// <returns>A JSON representation of the object.</returns>
        public virtual string ToJson()
        {
            return string.Empty;
        }
    }
}
