
namespace RadioControlledCarSimulator.Interfaces;

/// <summary>
/// Represents a command that can be executed.
/// </summary>
public interface ICommand
{
    /// <summary>
    /// Executes the command.
    /// </summary>
    /// <returns>True if the command was executed successfully, otherwise false.</returns>
    bool Execute();
}
