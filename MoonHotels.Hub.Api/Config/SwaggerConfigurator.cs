using System.Reflection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MoonHotels.Hub.Api.Config
{
    /// <summary>
    /// Provides extension methods for configuring Swagger in the IServiceCollection.
    /// </summary>
    public static class SwaggerConfigurator
    {
        /// <summary>
        /// Configures Swagger generation for the specified IServiceCollection.
        /// </summary>
        /// <param name="services">The IServiceCollection to configure Swagger for.</param>
        public static void ConfigureSwaggerGen(this IServiceCollection services)
        {
            _ = services.AddSwaggerGen(c =>
            {
                ConfigureSwaggerDoc(c);
            });
        }

        /// <summary>
        /// Configures the Swagger document information.
        /// </summary>
        /// <param name="options">The SwaggerGenOptions to configure.</param>
        private static void ConfigureSwaggerDoc(SwaggerGenOptions options)
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Moon Hotels Hub",
                Version = "v1",
                Description = "A web api in asp.net core to manage the main functionality of a search engine for vacation room rental offers. " +
                "It contains an endpoint that, based on a search request, begins to perform searches based on this request in all its providers and responds through a web socket.",
                Contact = new OpenApiContact
                {
                    Name = "Mario David Riguera Castillo",
                    Url = new Uri("https://www.linkedin.com/in/mario-david-riguera-castillo/"),
                },
            });

            // using System.Reflection;
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        }
    }
}
