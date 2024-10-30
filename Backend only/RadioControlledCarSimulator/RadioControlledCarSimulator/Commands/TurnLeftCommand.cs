using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Commands;

/// <summary>
/// Represents a command to turn the car left.
/// </summary>
public class TurnLeftCommand : ICommand
{
    private readonly Car _car;

    /// <summary>
    /// Initializes a new instance of the <see cref="TurnLeftCommand"/> class.
    /// </summary>
    /// <param name="car">The car to control.</param>
    public TurnLeftCommand(Car car) => _car = car;

    /// <summary>
    /// Executes the turn left command.
    /// </summary>
    /// <returns>True if the turn left operation is completed, otherwise false.</returns>
    public bool Execute()
    {
        var completed = _car.TurnLeft();
        if (completed) _car.Draw();
        return completed;
    }
}
