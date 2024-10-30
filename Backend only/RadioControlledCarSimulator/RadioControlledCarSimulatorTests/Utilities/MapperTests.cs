using NUnit.Framework;
using RadioControlledCarSimulator.Models;
using RadioControlledCarSimulator.Utilities;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace RadioControlledCarSimulator.Tests
{
    public class MapperTests
    {
        [Test]
        public void ToDirections_ShouldReturnNorth_WhenInputIsN()
        {
            // Arrange
            var input = Directions.N;

            // Act
            var result = Mapper.ToDirections(input);

            // Assert
            Assert.AreEqual("North", result);
        }

        [Test]
        public void ToDirections_ShouldReturnEast_WhenInputIsE()
        {
            // Arrange
            var input = Directions.E;

            // Act
            var result = Mapper.ToDirections(input);

            // Assert
            Assert.AreEqual("East", result);
        }

        [Test]
        public void ToDirections_ShouldReturnSouth_WhenInputIsS()
        {
            // Arrange
            var input = Directions.S;

            // Act
            var result = Mapper.ToDirections(input);

            // Assert
            Assert.AreEqual("South", result);
        }

        [Test]
        public void ToDirections_ShouldReturnWest_WhenInputIsW()
        {
            // Arrange
            var input = Directions.W;

            // Act
            var result = Mapper.ToDirections(input);

            // Assert
            Assert.AreEqual("West", result);
        }

        [Test]
        public void ToDirections_ShouldReturnUnknown_WhenInputIsInvalid()
        {
            // Arrange
            var input = (Directions)10; // Invalid input

            // Act
            var result = Mapper.ToDirections(input);

            // Assert
            Assert.AreEqual("Unknown", result);
        }
    }
}
