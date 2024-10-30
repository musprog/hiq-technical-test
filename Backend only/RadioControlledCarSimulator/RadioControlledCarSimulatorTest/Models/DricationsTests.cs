using NUnit.Framework;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Tests
{
    public class DricationsTests
    {
        [Test]
        public void Directions_Enum_Should_Have_Four_Values()
        {
            // Arrange

            // Act

            // Assert
            Assert.Equals(4, System.Enum.GetValues(typeof(Directions)).Length);
        }
    }
}
