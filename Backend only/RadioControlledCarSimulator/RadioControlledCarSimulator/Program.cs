using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RadioControlledCarSimulator.Commands;
using RadioControlledCarSimulator.Extensions;
using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Utilities;

namespace RadioControlledCarSimulator;
public class Program
{
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
