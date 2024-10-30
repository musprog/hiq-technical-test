using NUnit.Framework;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Tests
{
    public class MovementsTests
    {
        [Test]
        public void MovementsEnum_ShouldHaveCorrectValues()
        {
            // Arrange

            // Act

            // Assert
            Assert.Equals("L", Movements.L.ToString());
            Assert.Equals("R", Movements.R.ToString());
            Assert.Equals("F", Movements.F.ToString());
            Assert.Equals("B", Movements.B.ToString());
        }
    }
}
