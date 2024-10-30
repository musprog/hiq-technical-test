using Microsoft.Extensions.Logging;
namespace RadioControlledCarSimulator.Extensions;

/// <summary>
/// Handles exceptions that occur during the simulation.
/// </summary>
public class ExceptionHandler
{
    private readonly ILogger<ExceptionHandler> _logger;

    public ExceptionHandler(ILogger<ExceptionHandler> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Handles the specified action asynchronously.
    /// </summary>
    /// <param name="action">The action to handle.</param>
    public async Task HandleAsync(Func<Task> action)
    {
        try
        {
            await action();
        }
        catch (SimulationException ex)
        {
            _logger.LogError($"Simulation error: {ex.Message}");
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Unhandled exception: {ex.Message}");
            Console.WriteLine("An unexpected error occurred. Please try again.");
        }
    }
}
