using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Commands;

/// <summary>
/// Represents a command to move the car forward.
/// </summary>
public class MoveForwardCommand : ICommand
{
    private readonly Car _car;

    /// <summary>
    /// Initializes a new instance of the <see cref="MoveForwardCommand"/> class.
    /// </summary>
    /// <param name="car">The car to be moved forward.</param>
    public MoveForwardCommand(Car car) => _car = car;

    /// <summary>
    /// Executes the move forward command.
    /// </summary>
    /// <returns>True if the move forward operation is completed successfully, otherwise false.</returns>
    public bool Execute()
    {
        var completed = _car.MoveForward();
        if (completed) _car.Draw();
        return completed;
    }
}
