using Moq;
using NUnit.Framework;
using RadioControlledCarSimulator.Commands;
using RadioControlledCarSimulator.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadioControlledCarSimulator.Commands.Tests
{
    [TestFixture()]
    public class CommandHandlerTests
    {
        [Test()]
        public void SetCommandAsyncTest()
        {
            Assert.Fail();
        }
    }
}

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
        public async Task SetCommandAsync_AddsCommandToList()
        {
            // Arrange
            var command = commandMock.Object;

            // Act
            await commandHandler.SetCommandAsync(command);

            // Assert
            Assert.Equals(command, commandHandler.ExecuteCommandsAsync);
        }

        [Test]
        public async Task ExecuteCommandsAsync_ExecutesAllCommands()
        {
            // Arrange
            var command1Mock = new Mock<ICommand>();
            var command2Mock = new Mock<ICommand>();
            var command3Mock = new Mock<ICommand>();

            commandHandler.SetCommandAsync(command1Mock.Object);
            commandHandler.SetCommandAsync(command2Mock.Object);
            commandHandler.SetCommandAsync(command3Mock.Object);

            // Act
            var result = await commandHandler.ExecuteCommandsAsync();

            // Assert
            Assert.That(result, Is.True);
            command1Mock.Verify(c => c.Execute(), Times.Once);
            command2Mock.Verify(c => c.Execute(), Times.Once);
            command3Mock.Verify(c => c.Execute(), Times.Once);
        }
    }
}
