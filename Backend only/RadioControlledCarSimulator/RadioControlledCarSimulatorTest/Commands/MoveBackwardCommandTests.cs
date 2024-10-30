using NUnit.Framework;
using Moq;
using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;
using RadioControlledCarSimulator.Commands;

namespace RadioControlledCarSimulator.Tests
{
    [TestFixture]
    public class MoveBackwardCommandTests
    {
        [Test]
        public void Execute_ShouldCallMoveBackwardAndDraw_WhenCompletedIsTrue()
        {
            // Arrange
            var carMock = new Mock<Car>();
            carMock.Setup(c => c.MoveBackward()).Returns(true);
            carMock.Setup(c => c.Draw());

            var moveBackwardCommand = new MoveBackwardCommand(carMock.Object);

            // Act
            var result = moveBackwardCommand.Execute();

            // Assert
            Assert.That(result, Is.True);
            carMock.Verify(c => c.MoveBackward(), Times.Once);
            carMock.Verify(c => c.Draw(), Times.Once);
        }

        [Test]
        public void Execute_ShouldOnlyCallMoveBackward_WhenCompletedIsFalse()
        {
            // Arrange
            var carMock = new Mock<Car>();
            carMock.Setup(c => c.MoveBackward()).Returns(false);

            var moveBackwardCommand = new MoveBackwardCommand(carMock.Object);

            // Act
            var result = moveBackwardCommand.Execute();

            // Assert
            Assert.That(result, Is.False);
            carMock.Verify(c => c.MoveBackward(), Times.Once);
            carMock.Verify(c => c.Draw(), Times.Never);
        }
    }
}
