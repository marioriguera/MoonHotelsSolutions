﻿using Microsoft.Extensions.DependencyInjection;
using Spedia.Services.Business;
using Spedia.Services.Contracts;

namespace Spedia.Services.Dependencies
{
    /// <summary>
    /// Register core layer dependency injections.
    /// </summary>
    public static class Register
    {
        /// <summary>
        /// Configure and register the necessary dependencies in the application's dependency injection container.
        /// </summary>
        /// <param name="services">The collection of services to which the dependencies will be added.</param>
        /// <returns>The same collection of services with dependencies added.</returns>
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<ISearchRooms, SearchRoomsServices>();
            return services;
        }
    }
}
