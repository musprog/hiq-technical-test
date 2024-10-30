using NUnit.Framework;
using Moq;
using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;
using RadioControlledCarSimulator.Commands;

namespace RadioControlledCarSimulator.Tests
{
    [TestFixture]
    public class MoveForwardCommandTests
    {
        [Test]
        public void Execute_ShouldCallMoveForwardAndDraw_WhenExecuted()
        {
            // Arrange
            var carMock = new Mock<Car>();
            carMock.Setup(c => c.MoveForward()).Returns(true);
            var car = carMock.Object;
            var moveForwardCommand = new MoveForwardCommand(car);

            // Act
            var result = moveForwardCommand.Execute();

            // Assert
            carMock.Verify(c => c.MoveForward(), Times.Once);
            carMock.Verify(c => c.Draw(), Times.Once);
            Assert.That(result, Is.True);
        }
    }
}
