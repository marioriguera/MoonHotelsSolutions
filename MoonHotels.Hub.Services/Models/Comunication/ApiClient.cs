using Newtonsoft.Json;
using System.Text;

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
        /// Sends a POST request to the specified API URL with the provided request body.
        /// </summary>
        /// <returns>The response body received from the API.</returns>
        public async Task PostDataAsync()
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
            catch (Exception)
            {
                Dispose();
                throw;
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
    }
}
