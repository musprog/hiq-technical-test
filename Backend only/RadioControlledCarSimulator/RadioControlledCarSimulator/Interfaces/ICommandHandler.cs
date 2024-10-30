
namespace RadioControlledCarSimulator.Interfaces;

/// <summary>
/// Represents a command handler interface.
/// </summary>
public interface ICommandHandler
{
    /// <summary>
    /// Sets the command to be executed.
    /// </summary>
    /// <param name="command">The command to be set.</param>
    Task SetCommandAsync(ICommand command);

    /// <summary>
    /// Executes the commands asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task<bool> ExecuteCommandsAsync();
}
