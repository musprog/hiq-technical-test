using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RadioControlledCarSimulator.Commands;
using RadioControlledCarSimulator.Extensions;
using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;
using RadioControlledCarSimulator.Utilities;
using System;
using System.Text;

namespace RadioControlledCarSimulator;
public class Program
{
    public static async Task Main(string[] args)
    {
        // Set up dependency injection and logging
        var serviceProvider = new ServiceCollection()
            .AddLogging(configure => configure.AddConsole())
            .AddTransient<ExceptionHandler>() 
            .AddTransient<ICommandHandler, CommandHandler>() 
            .AddTransient<SimulationIO>() 
            .AddTransient<CarSimulation>() 
            .BuildServiceProvider();

        var exceptionHandler = serviceProvider.GetRequiredService<ExceptionHandler>();
        var carSimulation = serviceProvider.GetRequiredService<CarSimulation>();

        // Use the exception handler to run the simulation
        await exceptionHandler.HandleAsync(carSimulation.RunSimulationAsync);
    }
}
