using NUnit.Framework;
using RadioControlledCarSimulator.Commands;
using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;
using Moq;
using RadioControlledCarSimulator.Extensions;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace RadioControlledCarSimulator.Tests.Commands
{
    public class CommandInvokerTests
    {
        [Test]
        public void InvokeCommand_WithValidCommand_ReturnsCorrectCommand()
        {
            // Arrange
            string command = "F";
            Room room = new Room(5, 5);
            Car car = new Car(2,2, Directions.N, room);

            // Act
            ICommand result = CommandInvoker.InvokeCommand(command, car);

            // Assert
            Assert.IsInstanceOfType<MoveForwardCommand>(result);
        }

        [Test]
        public void InvokeCommand_WithInvalidCommand_ThrowsSimulationException()
        {
            // Arrange
            string command = "X";
            Room room = new Room(10, 15);
            Car car = new Car(5, 10, Directions.S, room);

            // Act & Assert
            Assert.ThrowsException<SimulationException>(() => CommandInvoker.InvokeCommand(command, car));
        }
    }
}
