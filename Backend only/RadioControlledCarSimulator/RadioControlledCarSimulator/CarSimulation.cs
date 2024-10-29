using Microsoft.Extensions.Logging;
using RadioControlledCarSimulator.Commands;
using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;
using RadioControlledCarSimulator.Utilities;

namespace RadioControlledCarSimulator
{
    public class CarSimulation
    {
        private readonly ICommandHandler commandHandler;
        private readonly SimulationIO simulationIO;

        private readonly ILogger<Car> logger;

        public CarSimulation(ILogger<Car> logger, ICommandHandler commandHandler, SimulationIO simulationIO)
        {
            this.logger = logger;
            this.commandHandler = commandHandler;
            this.simulationIO = simulationIO;
        }

        public async Task RunSimulationAsync()
        {
            var car = await simulationIO.StartPostion().ConfigureAwait(true);
            await ExecuteCommandsAsync(car).ConfigureAwait(true);
        }

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
}
