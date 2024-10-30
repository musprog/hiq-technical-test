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
        public void Execute_WhenCalled_CallsTurnLeftMethodOnCar()
        {
            // Arrange
            var carMock = new Mock<Car>();
            var command = new TurnLeftCommand(carMock.Object);

            // Act
            command.Execute();

            // Assert
            carMock.Verify(c => c.TurnLeft(), Times.Once);
        }

        [Test]
        public void Execute_WhenTurnLeftReturnsTrue_CallsDrawMethodOnCar()
        {
            // Arrange
            var carMock = new Mock<Car>();
            carMock.Setup(c => c.TurnLeft()).Returns(true);
            var command = new TurnLeftCommand(carMock.Object);

            // Act
            command.Execute();

            // Assert
            carMock.Verify(c => c.Draw(), Times.Once);
        }

        [Test]
        public void Execute_WhenTurnLeftReturnsFalse_DoesNotCallDrawMethodOnCar()
        {
            // Arrange
            var carMock = new Mock<Car>();
            carMock.Setup(c => c.TurnLeft()).Returns(false);
            var command = new TurnLeftCommand(carMock.Object);

            // Act
            command.Execute();

            // Assert
            carMock.Verify(c => c.Draw(), Times.Never);
        }
    }
}
