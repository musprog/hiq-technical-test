using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using RadioControlledCarSimulator.Extensions;
using System;
using System.Threading.Tasks;

namespace RadioControlledCarSimulatorTest.Extensions
{
    public class ExceptionHandlerTests
    {
        private Mock<ILogger<ExceptionHandler>> _loggerMock;
        private ExceptionHandler _exceptionHandler;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<ExceptionHandler>>();
            _exceptionHandler = new ExceptionHandler(_loggerMock.Object);
        }

        [Test]
        public async Task HandleAsync_WithSimulationException_LogsErrorAndWritesErrorMessage()
        {
            // Arrange
            var simulationException = new SimulationException("Simulation error message");

            // Act
            await _exceptionHandler.HandleAsync(() => throw simulationException);

            // Assert
            _loggerMock.Verify(x => x.LogError($"Simulation error: {simulationException.Message}"), Times.Once);
            _loggerMock.VerifyNoOtherCalls();
        }

        [Test]
        public async Task HandleAsync_WithGenericException_LogsErrorAndWritesGenericErrorMessage()
        {
            // Arrange
            var genericException = new Exception("Generic error message");

            // Act
            await _exceptionHandler.HandleAsync(() => throw genericException);

            // Assert
            _loggerMock.Verify(x => x.LogError($"Unhandled exception: {genericException.Message}"), Times.Once);
            _loggerMock.VerifyNoOtherCalls();
        }
    }
}
