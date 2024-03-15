namespace MoonHotels.Hub.Api.Exceptions
{
    /// <summary>
    /// Represents an exception thrown when a search request is invalid.
    /// </summary>
    public class InvalidSearchException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidSearchException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public InvalidSearchException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidSearchException"/> class with a specified error message,
        /// parameter name, and parameter value.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="parameterName">The name of the parameter causing the exception.</param>
        /// <param name="parameterValue">The value of the parameter causing the exception.</param>
        public InvalidSearchException(string message, string parameterName, object? parameterValue)
            : base(message)
        {
            ParameterName = parameterName;
            ParameterValue = parameterValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidSearchException"/> class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public InvalidSearchException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Gets the name of the parameter causing the exception.
        /// </summary>
        public string ParameterName { get; } = string.Empty;

        /// <summary>
        /// Gets the value of the parameter causing the exception.
        /// </summary>
        public object? ParameterValue { get; }
    }
}
