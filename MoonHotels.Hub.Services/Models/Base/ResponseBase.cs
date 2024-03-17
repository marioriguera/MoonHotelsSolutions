namespace MoonHotels.Hub.Services.Models.Base
{
    /// <summary>
    /// Base class for response objects.
    /// </summary>
    internal abstract class ResponseBase : Base
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseBase"/> class with the specified ID and URL.
        /// </summary>
        /// <param name="id">The ID of the response.</param>
        /// <param name="url">The URL of the response.</param>
        protected ResponseBase(int id, string url)
            : base(id, url)
        {
        }

        // public bool IsResponseHasSend { get; set; }

        /// <summary>
        /// Converts the response to an EngineHub object.
        /// </summary>
        /// <returns>An EngineHub object.</returns>
        public abstract EngineHub ToEngineHub();
    }
}
