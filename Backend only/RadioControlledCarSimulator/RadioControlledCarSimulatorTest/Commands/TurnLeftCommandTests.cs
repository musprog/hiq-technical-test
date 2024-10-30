using NUnit.Framework;
using Moq;
using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;
using RadioControlledCarSimulator.Commands;

namespace RadioControlledCarSimulator.Tests
{
    [TestFixture]
    public class TurnLeftCommandTests
    {
        [Test]
        public void Execute_ShouldCallTurnLeftMethod()
        {
            // Arrange
            var carMock = new Mock<Car>();
            var turnLeftCommand = new TurnLeftCommand(carMock.Object);

            // Act
            turnLeftCommand.Execute();

            // Assert
            carMock.Verify(c => c.TurnLeft(), Times.Once);
        }

        [Test]
        public void Execute_WhenTurnLeftReturnsTrue_ShouldCallDrawMethod()
        {
            // Arrange
            var carMock = new Mock<Car>();
            carMock.Setup(c => c.TurnLeft()).Returns(true);
            var turnLeftCommand = new TurnLeftCommand(carMock.Object);

            // Act
            turnLeftCommand.Execute();

            // Assert
            carMock.Verify(c => c.Draw(), Times.Once);
        }

        [Test]
        public void Execute_WhenTurnLeftReturnsFalse_ShouldNotCallDrawMethod()
        {
            // Arrange
            var carMock = new Mock<Car>();
            carMock.Setup(c => c.TurnLeft()).Returns(false);
            var turnLeftCommand = new TurnLeftCommand(carMock.Object);

            // Act
            turnLeftCommand.Execute();

            // Assert
            carMock.Verify(c => c.Draw(), Times.Never);
        }
    }
}
