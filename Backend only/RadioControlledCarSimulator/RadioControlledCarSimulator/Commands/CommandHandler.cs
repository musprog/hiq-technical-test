using RadioControlledCarSimulator.Interfaces;

namespace RadioControlledCarSimulator.Commands
{
    public class CommandHandler : ICommandHandler
    {
        private readonly List<ICommand> commands;
        public CommandHandler() => commands = new List<ICommand>();

        public Task<bool> ExecuteCommandsAsync()
        {
            var reslut = commands.All(command => command.Execute());
            return Task.FromResult(reslut);
        }

        public Task SetCommandAsync(ICommand command)
        {
            commands.Add(command);
            return Task.CompletedTask;
        }
    }
}
