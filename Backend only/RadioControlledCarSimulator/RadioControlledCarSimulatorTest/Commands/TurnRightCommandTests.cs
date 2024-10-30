using NUnit.Framework;
using Moq;
using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;
using RadioControlledCarSimulator.Commands;

namespace RadioControlledCarSimulator.Tests
{
    public class TurnRightCommandTests
    {
        [Test]
        public void Execute_ShouldCallTurnRightMethod()
        {
            // Arrange
            var carMock = new Mock<Car>();
            carMock.Setup(c => c.TurnRight()).Returns(true);
            var car = carMock.Object;
            var turnRightCommand = new TurnRightCommand(car);

            // Act
            var result = turnRightCommand.Execute();

            // Assert
            carMock.Verify(c => c.TurnRight(), Times.Once);
        }

        [Test]
        public void Execute_ShouldCallDrawMethod_WhenTurnRightIsCompleted()
        {
            // Arrange
            var carMock = new Mock<Car>();
            carMock.Setup(c => c.TurnRight()).Returns(true);
            var car = carMock.Object;
            var turnRightCommand = new TurnRightCommand(car);

            // Act
            var result = turnRightCommand.Execute();

            // Assert
            carMock.Verify(c => c.Draw(), Times.Once);
        }

        [Test]
        public void Execute_ShouldNotCallDrawMethod_WhenTurnRightIsNotCompleted()
        {
            // Arrange
            var carMock = new Mock<Car>();
            carMock.Setup(c => c.TurnRight()).Returns(false);
            var car = carMock.Object;
            var turnRightCommand = new TurnRightCommand(car);

            // Act
            var result = turnRightCommand.Execute();

            // Assert
            carMock.Verify(c => c.Draw(), Times.Never);
        }
    }
}
