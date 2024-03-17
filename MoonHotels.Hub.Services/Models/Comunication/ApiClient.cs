using System.Text;
using MoonHotels.Hub.Services.Models.Base;
using MoonHotels.Hub.Services.Models.Suppliers.HotelLegs;
using MoonHotels.Hub.Services.Models.Suppliers.Spedia;
using MoonHotels.Hub.Services.Models.Suppliers.TravelDoorX;
using Newtonsoft.Json;

namespace MoonHotels.Hub.Services.Models.Comunication
{
    /// <summary>
    /// Represents an API client for making HTTP requests.
    /// </summary>
    internal class ApiClient : IDisposable
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiClient"/> class with the specified API URL and request body.
        /// </summary>
        /// <param name="apiUrl">The URL of the API.</param>
        /// <param name="requestBody">The request body to be sent in the HTTP POST request.</param>
        public ApiClient(string apiUrl, string requestBody)
        {
            _httpClient = new HttpClient();
            ApiUrl = apiUrl;
            RequestBody = requestBody;
        }

        /// <summary>
        /// Gets or sets the URL of the API.
        /// </summary>
        public string ApiUrl { get; set; }

        /// <summary>
        /// Gets or sets the request body to be sent in the HTTP POST request.
        /// </summary>
        public string RequestBody { get; set; }

        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        public string Response { get; set; } = string.Empty;

        /// <summary>
        /// Posts data asynchronously to the API and logs any exceptions.
        /// </summary>
        /// <param name="logger">The logger instance for logging exceptions.</param>
        public async Task PostDataAsync(NLog.ILogger logger)
        {
            try
            {
                // Create the request content with the body data
                var content = new StringContent(RequestBody, Encoding.UTF8, "application/json");

                // Send a POST request to the specified URL with the request content
                HttpResponseMessage response = await _httpClient.PostAsync(ApiUrl, content);

                // Check if the request was successful (status code 200)
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Dispose();
                    Response = responseBody;
                }
                else
                {
                    Dispose();

                    // If the request was not successful, handle the error as needed
                    throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, $"During the post request with the body {RequestBody} to the url {ApiUrl} an exception has occurred. Message: {ex.Message} .");
                Response = string.Empty;
                Dispose();
            }
        }

        /// <summary>
        /// Deserializes the response into the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the response to deserialize.</typeparam>
        /// <returns>The deserialized response object of type <typeparamref name="T"/>.</returns>
        public T DeserializeResponse<T>()
        {
            return JsonConvert.DeserializeObject<T>(Response) ?? throw new Exception($"Cant deserialize {nameof(Response)} in function {nameof(DeserializeResponse)}.");
        }

        /// <summary>
        /// Dispose httpClient field.
        /// </summary>
        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        /// <summary>
        /// Retrieves the response based on the API URL.
        /// </summary>
        /// <returns>The response object.</returns>
        internal ResponseBase GetResponse()
        {
            if (ApiUrl.Equals(new HotelLegsResponse(-1).Url, StringComparison.Ordinal))
            {
                return DeserializeResponse<HotelLegsResponse>();
            }

            if (ApiUrl.Equals(new SpediaResponse(-1).Url, StringComparison.Ordinal))
            {
                return DeserializeResponse<SpediaResponse>();
            }

            if (ApiUrl.Equals(new TravelDoorXResponse(-1).Url, StringComparison.Ordinal))
            {
                return DeserializeResponse<TravelDoorXResponse>();
            }

            throw new Exception($"Type of response not found.");
        }
    }
}
