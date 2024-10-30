using NUnit.Framework;
using RadioControlledCarSimulator.Commands;
using RadioControlledCarSimulator.Extensions;
using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;
using System;

namespace RadioControlledCarSimulator.Tests.Commands
{
    public class CommandInvokerTests
    {
        [Test]
        public void InvokeCommand_WithValidCommand_ReturnsCorrectCommand()
        {
            // Arrange
            Room room = new Room(5, 5);
            Car car = new Car(2, 2, Directions.N, room);
            
            string command = "F";

            // Act
            ICommand result = CommandInvoker.InvokeCommand(command, car);

            // Assert
            
            Assert.Equals(car, result);
        }

        [Test]
        public void InvokeCommand_WithInvalidCommand_ThrowsSimulationException()
        {
            // Arrange
            Room room = new Room(5, 5);
            Car car = new Car(2, 2, Directions.N, room);
            string command = "X";

            // Act & Assert
            Assert.Throws<SimulationException>(() => CommandInvoker.InvokeCommand(command, car));
        }
    }
}
