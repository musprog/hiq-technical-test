using NUnit.Framework;
using RadioControlledCarSimulator.Commands;
using RadioControlledCarSimulator.Models;
using Moq;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace RadioControlledCarSimulator.Tests
{
    [TestFixture]
    public class MoveBackwardCommandTests
    {
        [Test]
        public void Execute_ShouldCallMoveBackwardAndDraw_WhenCompleted()
        {
            // Arrange
            var carMock = new Mock<Car>();
            carMock.Setup(c => c.MoveBackward()).Returns(true);
            carMock.Setup(c => c.Draw());

            var moveBackwardCommand = new MoveBackwardCommand(carMock.Object);

            // Act
            var result = moveBackwardCommand.Execute();

            // Assert
            Assert.IsTrue(result);
            carMock.Verify(c => c.MoveBackward(), Times.Once);
            carMock.Verify(c => c.Draw(), Times.Once);
        }

        [Test]
        public void Execute_ShouldCallMoveBackwardAndNotDraw_WhenNotCompleted()
        {
            // Arrange
            var carMock = new Mock<Car>();
            carMock.Setup(c => c.MoveBackward()).Returns(false);

            var moveBackwardCommand = new MoveBackwardCommand(carMock.Object);

            // Act
            var result = moveBackwardCommand.Execute();

            // Assert
            Assert.IsFalse(result);
            carMock.Verify(c => c.MoveBackward(), Times.Once);
            carMock.Verify(c => c.Draw(), Times.Never);
        }
    }
}
