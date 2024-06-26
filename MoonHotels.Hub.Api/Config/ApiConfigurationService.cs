﻿using NLog;

namespace MoonHotels.Hub.Api.Config
{
    /// <summary>
    /// Manages api configuration service values.
    /// </summary>
    public sealed class ApiConfigurationService
    {
        #region Constructors

        /// <summary>
        /// Initializes static members of the <see cref="ApiConfigurationService"/> class.
        /// </summary>
        /// <remarks>
        /// Explicit static constructor to tell C# compiler not to mark type as before field initialization.
        /// </remarks>
        static ApiConfigurationService()
        {
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="ApiConfigurationService"/> class from being created.
        /// </summary>
        private ApiConfigurationService()
        {
        }
        #endregion

        #region Core Properties

        /// <summary>
        /// Gets current service configuration.
        /// </summary>
        public static ApiConfigurationService Current { get; } = new ApiConfigurationService();

        #endregion

        #region LogProperties

        /// <summary>
        /// Gets the NLog logger associated with the current class.
        /// </summary>
        public NLog.ILogger Logger { get; private set; } = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets or sets the log level.
        /// </summary>
        public NLog.LogLevel LogLevel { get; set; } = NLog.LogLevel.Trace;

        /// <summary>
        /// Gets or sets the log path to store log as file.
        /// </summary>
        public string LogPath { get; set; } = @"C:/Logs/MoonHotelsHub/MoonHotelsHub_Api.log";

        /// <summary>
        /// Gets or sets the log max file size before rolling.
        /// </summary>
        public long LogMaxFileSize { get; set; } = 104857600;
        #endregion
    }
}
