using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using RadioControlledCarSimulator.Commands;
using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;
using RadioControlledCarSimulator.Utilities;
using System.Threading.Tasks;

namespace RadioControlledCarSimulator.Tests
{
    public class CarSimulationTests
    {
        private Mock<ICommandHandler> commandHandlerMock;
        private Mock<SimulationIO> simulationIOMock;
        private Mock<ILogger<Car>> loggerMock;

        private CarSimulation carSimulation;

        [SetUp]
        public void Setup()
        {
            commandHandlerMock = new Mock<ICommandHandler>();
            simulationIOMock = new Mock<SimulationIO>();
            loggerMock = new Mock<ILogger<Car>>();

            carSimulation = new CarSimulation(loggerMock.Object, commandHandlerMock.Object, simulationIOMock.Object);
        }

        [Test]
        public async Task RunSimulationAsync_ShouldStartCarAndExecuteCommands()
        {
            // Arrange
            
            Room room = new Room(5, 5);
            Car car = new Car(2, 2, Directions.N, room);
            simulationIOMock.Setup(s => s.StartPostion()).ReturnsAsync(car);
            simulationIOMock.Setup(s => s.ReadCommandsInput()).Returns(new string[] { "command1", "command2" });
            commandHandlerMock.Setup(c => c.SetCommandAsync(It.IsAny<ICommand>())).Returns(Task.CompletedTask);
            commandHandlerMock.Setup(c => c.ExecuteCommandsAsync()).ReturnsAsync(true);

            // Act
            await carSimulation.RunSimulationAsync();

            // Assert
            simulationIOMock.Verify(s => s.StartPostion(), Times.Once);
            simulationIOMock.Verify(s => s.ReadCommandsInput(), Times.Once);
            commandHandlerMock.Verify(c => c.SetCommandAsync(It.IsAny<ICommand>()), Times.Exactly(2));
            commandHandlerMock.Verify(c => c.ExecuteCommandsAsync(), Times.Once);
            simulationIOMock.Verify(s => s.WriteCarPosition(car), Times.Once);
            simulationIOMock.Verify(s => s.SimulationFinished(true), Times.Once);
        }
    }
}
