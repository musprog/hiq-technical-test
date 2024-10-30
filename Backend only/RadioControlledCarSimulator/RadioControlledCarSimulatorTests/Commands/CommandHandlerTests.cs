using Moq;
using NUnit.Framework;
using RadioControlledCarSimulator.Commands;
using RadioControlledCarSimulator.Interfaces;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace RadioControlledCarSimulator.Tests.Commands
{
    [TestFixture]
    public class CommandHandlerTests
    {
        private CommandHandler commandHandler;
        private Mock<ICommand> commandMock;

        [SetUp]
        public void Setup()
        {
            commandHandler = new CommandHandler();
            commandMock = new Mock<ICommand>();
        }

        [Test]
        public async Task ExecuteCommandsAsync_AllCommandsExecute_ReturnsTrue()
        {
            // Arrange
            commandMock.Setup(command => command.Execute()).Returns(true);
            commandHandler.SetCommandAsync(commandMock.Object);

            // Act
            var result = await commandHandler.ExecuteCommandsAsync();

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExecuteCommandsAsync_NotAllCommandsExecute_ReturnsFalse()
        {
            // Arrange
            commandMock.Setup(command => command.Execute()).Returns(true);
            commandHandler.SetCommandAsync(commandMock.Object);
            commandMock.Setup(command => command.Execute()).Returns(false);

            // Act
            var result = await commandHandler.ExecuteCommandsAsync();

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task SetCommandAsync_AddsCommandToCommandsList()
        {
            // Arrange
            commandMock.Setup(command => command.Execute()).Returns(true);

            // Act
            await commandHandler.SetCommandAsync(commandMock.Object);

            // Assert
            Assert.AreEqual(1, commandHandler.ExecuteCommandsAsync().Id);
        }
    }
}
