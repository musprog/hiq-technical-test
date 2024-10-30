using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RadioControlledCarSimulator.Commands;
using RadioControlledCarSimulator.Extensions;
using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Utilities;

namespace RadioControlledCarSimulator;
/// <summary>
/// Represents the entry point of the program.
/// </summary>
public class Program
{
    /// <summary>
    /// The main method of the program.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    public static async Task Main(string[] args)
    {
        // Set up dependency injection and logging
        var serviceProvider = new ServiceCollection()
            .AddLogging(configure => configure.AddConsole())
            .AddSingleton<ExceptionHandler>()
            .AddSingleton<ICommandHandler, CommandHandler>()
            .AddSingleton<SimulationIO>()
            .AddSingleton<CarSimulation>()
            .BuildServiceProvider();

        var exceptionHandler = serviceProvider.GetRequiredService<ExceptionHandler>();
        var carSimulation = serviceProvider.GetRequiredService<CarSimulation>();

        // Use the exception handler to run the simulation
        await exceptionHandler.HandleAsync(carSimulation.RunSimulationAsync);
    }
}
