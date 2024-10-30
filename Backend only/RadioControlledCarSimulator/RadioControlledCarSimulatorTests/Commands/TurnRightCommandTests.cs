using NUnit.Framework;
using Moq;
using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;
using RadioControlledCarSimulator.Commands;

namespace RadioControlledCarSimulator.Tests
{
    [TestFixture]
    public class TurnRightCommandTests
    {
        [Test]
        public void Execute_ShouldCallTurnRightMethod()
        {
            // Arrange
            var carMock = new Mock<Car>();
            var command = new TurnRightCommand(carMock.Object);

            // Act
            command.Execute();

            // Assert
            carMock.Verify(c => c.TurnRight(), Times.Once);
        }

        [Test]
        public void Execute_ShouldCallDrawMethod_WhenTurnRightIsCompleted()
        {
            // Arrange
            var carMock = new Mock<Car>();
            carMock.Setup(c => c.TurnRight()).Returns(true);
            var command = new TurnRightCommand(carMock.Object);

            // Act
            command.Execute();

            // Assert
            carMock.Verify(c => c.Draw(), Times.Once);
        }

        [Test]
        public void Execute_ShouldNotCallDrawMethod_WhenTurnRightIsNotCompleted()
        {
            // Arrange
            var carMock = new Mock<Car>();
            carMock.Setup(c => c.TurnRight()).Returns(false);
            var command = new TurnRightCommand(carMock.Object);

            // Act
            command.Execute();

            // Assert
            carMock.Verify(c => c.Draw(), Times.Never);
        }
    }
}
