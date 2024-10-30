using NUnit.Framework;
using RadioControlledCarSimulator.Extensions;

namespace RadioControlledCarSimulator.Tests.Extensions
{
    public class SimulationExceptionTests
    {
        [Test]
        public void Constructor_WithMessage_SetsMessageProperty()
        {
            // Arrange
            string message = "Test message";

            // Act
            var exception = new SimulationException(message);

            // Assert
            Assert.Equals(message, exception.Message);
        }

        [Test]
        public void Constructor_WithMessageAndInnerException_SetsMessageAndInnerExceptionProperties()
        {
            // Arrange
            string message = "Test message";
            var innerException = new System.Exception("Inner exception");

            // Act
            var exception = new SimulationException(message, innerException);

            // Assert
            Assert.Equals(message, exception.Message);
            Assert.Equals(innerException, exception.InnerException);
        }
    }
}
