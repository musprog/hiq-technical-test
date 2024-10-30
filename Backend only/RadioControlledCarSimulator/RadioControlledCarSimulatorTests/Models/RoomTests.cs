using NUnit.Framework;
using RadioControlledCarSimulator.Models;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace RadioControlledCarSimulator.Tests.Models
{
    [TestFixture]
    public class RoomTests
    {
        [Test]
        public void IsWithinRoomRange_ShouldReturnTrue_WhenCoordinatesAreWithinRoomRange()
        {
            // Arrange
            int width = 10;
            int height = 8;
            Room room = new Room(width, height);

            // Act
            bool result = room.IsWithinRoomRange(5, 5);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsWithinRoomRange_ShouldReturnFalse_WhenXCoordinateIsOutsideRoomRange()
        {
            // Arrange
            int width = 10;
            int height = 8;
            Room room = new Room(width, height);

            // Act
            bool result = room.IsWithinRoomRange(12, 5);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsWithinRoomRange_ShouldReturnFalse_WhenYCoordinateIsOutsideRoomRange()
        {
            // Arrange
            int width = 10;
            int height = 8;
            Room room = new Room(width, height);

            // Act
            bool result = room.IsWithinRoomRange(5, 10);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsWithinRoomRange_ShouldReturnFalse_WhenCoordinatesAreOutsideRoomRange()
        {
            // Arrange
            int width = 10;
            int height = 8;
            Room room = new Room(width, height);

            // Act
            bool result = room.IsWithinRoomRange(12, 10);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
