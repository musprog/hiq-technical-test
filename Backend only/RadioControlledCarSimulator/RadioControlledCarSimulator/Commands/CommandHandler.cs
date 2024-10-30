using RadioControlledCarSimulator.Interfaces;

namespace RadioControlledCarSimulator.Commands;

/// <summary>
/// Represents a command handler that executes a list of commands.
/// </summary>
public class CommandHandler : ICommandHandler
{
    private readonly List<ICommand> commands;

    /// <summary>
    /// Initializes a new instance of the CommandHandler class.
    /// </summary>
    public CommandHandler() => commands = new List<ICommand>();

    /// <summary>
    /// Executes all the commands in the command list.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The task result is true if all commands were executed successfully; otherwise, false.</returns>
    public Task<bool> ExecuteCommandsAsync()
    {
        var result = commands.All(command => command.Execute());
        return Task.FromResult(result);
    }

    /// <summary>
    /// Adds a command to the list of commands.
    /// </summary>
    /// <param name="command">The command to be added.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task SetCommandAsync(ICommand command)
    {
        commands.Add(command);
        return Task.CompletedTask;
    }
}
