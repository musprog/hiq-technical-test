using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using RadioControlledCarSimulator.Commands;
using RadioControlledCarSimulator.Extensions;
using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Utilities;

namespace RadioControlledCarSimulator.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        private ServiceProvider _serviceProvider;
        private Mock<ExceptionHandler> _exceptionHandlerMock;
        private Mock<CarSimulation> _carSimulationMock;

        [SetUp]
        public void Setup()
        {
            _exceptionHandlerMock = new Mock<ExceptionHandler>();
            _carSimulationMock = new Mock<CarSimulation>();

            _serviceProvider = new ServiceCollection()
                .AddSingleton(_exceptionHandlerMock.Object)
                .AddSingleton<ICommandHandler, CommandHandler>()
                .AddSingleton<SimulationIO>()
                .AddSingleton(_carSimulationMock.Object)
                .BuildServiceProvider();
        }

        [Test]
        public void Main_ShouldRunSimulationAsync()
        {
            // Arrange
            var program = new Program();

            // Act
            Program.Main(new string[] { }).GetAwaiter().GetResult();

            // Assert
            _exceptionHandlerMock.Verify(eh => eh.HandleAsync(_carSimulationMock.Object.RunSimulationAsync), Times.Once);
        }
    }
}
