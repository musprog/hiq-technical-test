using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;
using RadioControlledCarSimulator.Models;
using RadioControlledCarSimulator.Utilities;
using System;
using System.IO;
using System.Text;

namespace RadioControlledCarSimulator.Tests.Utilities
{
    public class SimulationIOTests
    {
        private SimulationIO _simulationIO;

        [SetUp]
        public void Setup()
        {
            _simulationIO = new SimulationIO(new NullLogger<SimulationIO>());
        }

        [Test]
        public void CreateRoom_ValidInput_ReturnsRoom()
        {
            // Arrange
            int width = 5;
            int height = 5;
            string input = $"{width}{Environment.NewLine}{height}";
            Console.SetIn(new StringReader(input));

            // Act
            Room room = _simulationIO.CreateRoom();

            // Assert
            Assert.Equals(width, room.Width);
            Assert.Equals(height, room.Height);
        }

        [Test]
        public void CreateCar_ValidInput_ReturnsCar()
        {
            // Arrange
            int startX = 2;
            int startY = 3;
            Directions startDirection = Directions.N;
            string input = $"{startX}{Environment.NewLine}{startY}{Environment.NewLine}{startDirection}";
            Console.SetIn(new StringReader(input));

            // Act
            Room room = new Room(5, 5);
            Car car = _simulationIO.CreateCar(room);

            // Assert
            Assert.Equals(startX, car.X);
            Assert.Equals(startY, car.Y);
            Assert.Equals(startDirection, car.Direction);
            
        }

        [Test]
        public void ReadPositiveIntegerInput_ValidInput_ReturnsInteger()
        {
            // Arrange
            int expected = 10;
            string input = $"{expected}";
            Console.SetIn(new StringReader(input));

            // Act
            int result = SimulationIO.ReadPositiveIntegerInput("Enter a positive integer: ");

            // Assert
            Assert.Equals(expected, result);
        }

        [Test]
        public void ReadDirectionInput_ValidInput_ReturnsDirection()
        {
            // Arrange
            Directions expected = Directions.E;
            string input = $"{expected}";
            Console.SetIn(new StringReader(input));

            // Act
            Directions result = _simulationIO.ReadDirectionInput("Enter a direction: ");

            // Assert
            Assert.Equals(expected, result);
        }

        [Test]
        public void ReadCommandsInput_ValidInput_ReturnsCommands()
        {
            // Arrange
            string[] expected = { "F", "B", "L", "R" };
            string input = $"{string.Join(" ", expected)}";
            Console.SetIn(new StringReader(input));

            // Act
            string[] result = _simulationIO.ReadCommandsInput();

            // Assert
            Assert.Equals(expected, result);
        }
    }
}
