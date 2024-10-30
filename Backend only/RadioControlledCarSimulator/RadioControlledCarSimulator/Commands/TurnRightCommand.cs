using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Commands;

/// <summary>
/// Represents a command to turn the car to the right.
/// </summary>
public class TurnRightCommand : ICommand
{
    private readonly Car _car;

    public TurnRightCommand(Car car) => _car = car;

    /// <summary>
    /// Executes the turn right command.
    /// </summary>
    /// <returns>True if the turn was completed successfully, otherwise false.</returns>
    public bool Execute()
    {
        var completed = _car.TurnRight();
        if (completed) _car.Draw();
        return completed;
    }
}
