using Microsoft.Extensions.Logging;
using RadioControlledCarSimulator.Commands;
using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;
using RadioControlledCarSimulator.Utilities;

namespace RadioControlledCarSimulator;

/// <summary>
/// Represents a simulation of a radio-controlled car.
/// </summary>
public class CarSimulation
{
    private readonly ICommandHandler commandHandler;
    private readonly SimulationIO simulationIO;

    private readonly ILogger<Car> logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="CarSimulation"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="commandHandler">The command handler.</param>
    /// <param name="simulationIO">The simulation IO.</param>
    public CarSimulation(ILogger<Car> logger, ICommandHandler commandHandler, SimulationIO simulationIO)
    {
        this.logger = logger;
        this.commandHandler = commandHandler;
        this.simulationIO = simulationIO;
    }

    /// <summary>
    /// Runs the car simulation asynchronously.
    /// </summary>
    public async Task RunSimulationAsync()
    {
        var car = await simulationIO.StartPostion().ConfigureAwait(true);
        await ExecuteCommandsAsync(car).ConfigureAwait(true);
    }

    /// <summary>
    /// Executes the commands asynchronously for the given car.
    /// </summary>
    /// <param name="car">The car to execute commands for.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    private async Task ExecuteCommandsAsync(Car car)
    {
        // Command sequence
        string[] commands = simulationIO.ReadCommandsInput();

        foreach (var command in commands)
        {
            var invokedCommand = CommandInvoker.InvokeCommand(command, car);
            await commandHandler.SetCommandAsync(invokedCommand).ConfigureAwait(false);
        }

        var reslut = await commandHandler.ExecuteCommandsAsync().ConfigureAwait(true);

        simulationIO.WriteCarPosition(car);
        simulationIO.SimulationFinished(reslut);
    }
}
