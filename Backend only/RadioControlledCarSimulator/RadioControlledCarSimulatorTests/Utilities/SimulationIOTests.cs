using Microsoft.Extensions.Logging.Abstractions;
using NUnit.Framework;
using RadioControlledCarSimulator.Models;
using RadioControlledCarSimulator.Utilities;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace RadioControlledCarSimulator.Tests.Utilities
{
    public class SimulationIOTests
    {
        private SimulationIO _simulationIO;

        [SetUp]
        public void Setup()
        {
            var logger = new NullLogger<SimulationIO>();
            _simulationIO = new SimulationIO(logger);
        }

        [Test]
        public void StartPosition_ShouldCreateRoomAndCar()
        {
            // Arrange
            var expectedWidth = 5;
            var expectedHeight = 5;
            var expectedStartX = 2;
            var expectedStartY = 3;
            var expectedStartDirection = Directions.N;

            var input = new StringReader($"{expectedWidth}{Environment.NewLine}{expectedHeight}{Environment.NewLine}" +
                $"{expectedStartX}{Environment.NewLine}{expectedStartY}{Environment.NewLine}" +
                $"{expectedStartDirection.ToString().ToUpper()}{Environment.NewLine}");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            var car = _simulationIO.StartPostion().Result;

            // Assert
            Assert.IsNotNull(car);
            Assert.AreEqual(expectedStartX, car.X);
            Assert.AreEqual(expectedStartY, car.Y);
            Assert.AreEqual(expectedStartDirection, car.Direction);
        }

        [Test]
        public void CreateRoom_ShouldReturnRoomWithCorrectDimensions()
        {
            // Arrange
            var expectedWidth = 5;
            var expectedHeight = 5;

            var input = new StringReader($"{expectedWidth}{Environment.NewLine}{expectedHeight}{Environment.NewLine}");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            var room = _simulationIO.CreateRoom();

            // Assert
            Assert.IsNotNull(room);
            Assert.AreEqual(expectedWidth, room.Width);
            Assert.AreEqual(expectedHeight, room.Height);
        }

        [Test]
        public void CreateCar_ShouldReturnCarWithCorrectStartPosition()
        {
            // Arrange
            var room = new Room(5, 5);
            var expectedStartX = 2;
            var expectedStartY = 3;
            var expectedStartDirection = Directions.N;

            var input = new StringReader($"{expectedStartX}{Environment.NewLine}{expectedStartY}{Environment.NewLine}" +
                $"{expectedStartDirection.ToString().ToUpper()}{Environment.NewLine}");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            var car = _simulationIO.CreateCar(room);

            // Assert
            Assert.IsNotNull(car);
            Assert.AreEqual(expectedStartX, car.X);
            Assert.AreEqual(expectedStartY, car.Y);
            Assert.AreEqual(expectedStartDirection, car.Direction);

        }

        [Test]
        public void ReadPositiveIntegerInput_ShouldReturnValidPositiveInteger()
        {
            // Arrange
            var expectedInput = 5;

            var input = new StringReader($"{expectedInput}{Environment.NewLine}");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            var result = SimulationIO.ReadPositiveIntegerInput("Enter a positive integer: ");

            // Assert
            Assert.AreEqual(expectedInput, result);
        }

        [Test]
        public void ReadDirectionInput_ShouldReturnValidDirection()
        {
            // Arrange
            var expectedDirection = Directions.N;

            var input = new StringReader($"{expectedDirection.ToString().ToUpper()}{Environment.NewLine}");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            var result = _simulationIO.ReadDirectionInput("Enter a direction (N, E, S, W): ");

            // Assert
            Assert.AreEqual(expectedDirection, result);
        }

        [Test]
        public void ReadCommandsInput_ShouldReturnValidCommands()
        {
            // Arrange
            var expectedCommands = new string[] { "F", "B", "L", "R" };

            var input = new StringReader($"{string.Join(" ", expectedCommands)}{Environment.NewLine}");
            Console.SetIn(input);

            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            var result = _simulationIO.ReadCommandsInput();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCommands.Length, result.Length);
            CollectionAssert.AreEqual(expectedCommands, result);
        }

        [Test]
        public void CarMoving_ShouldPrintCorrectMessage()
        {
            // Arrange
            var expectedMoving = "forward";
            var expectedX = 2;
            var expectedY = 3;
            var expectedDirection = Directions.N;

            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            SimulationIO.CarMoving(true, expectedMoving, expectedX, expectedY, expectedDirection);

            // Assert
            var expectedOutput = $"Car is moved {expectedMoving} to position: ({expectedX}, {expectedY}) to ward " +
                $"{Mapper.ToDirections(expectedDirection)}{Environment.NewLine}";
            Assert.AreEqual(expectedOutput, output.ToString());
        }

        [Test]
        public void CarTurning_ShouldPrintCorrectMessage()
        {
            // Arrange
            var expectedTurn = "right";
            var expectedX = 2;
            var expectedY = 3;
            var expectedDirection = Directions.N;

            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            SimulationIO.CarTurning(expectedTurn, expectedX, expectedY, expectedDirection);

            // Assert
            var expectedOutput = $"Car is turned {expectedTurn} to position: ({expectedX}, {expectedY}) to ward " +
                $"{Mapper.ToDirections(expectedDirection)}{Environment.NewLine}";
            Assert.AreEqual(expectedOutput, output.ToString());
        }

        [Test]
        public void WriteCarPosition_ShouldPrintCorrectMessage()
        {
            // Arrange
            var car = new Car(2, 3, Directions.N, new Room(5, 5));

            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            _simulationIO.WriteCarPosition(car);

            // Assert
            var expectedOutput = $"{car.ToString()}{Environment.NewLine}";
            Assert.AreEqual(expectedOutput, output.ToString());
        }

        [Test]
        public void SimulationFinished_ShouldPrintCorrectMessage()
        {
            // Arrange
            var result = true;

            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            _simulationIO.SimulationFinished(result);

            // Assert
            var expectedOutput = "Simulation is finished!" + Environment.NewLine;
            Assert.AreEqual(expectedOutput, output.ToString());
        }
    }
}
