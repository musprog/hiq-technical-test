namespace RadioControlledCarSimulator.Extensions;

/// <summary>
/// Represents an exception that occurs during the simulation of a radio-controlled car.
/// </summary>
public class SimulationException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SimulationException"/> class with the specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public SimulationException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SimulationException"/> class with the specified error message and inner exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public SimulationException(string message, Exception innerException) : base(message, innerException) { }
}
