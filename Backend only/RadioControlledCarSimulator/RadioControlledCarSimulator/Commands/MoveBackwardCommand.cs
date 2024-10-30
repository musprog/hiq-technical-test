
using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Commands;

/// <summary>
/// Represents a command to move the car backward.
/// </summary>
public class MoveBackwardCommand : ICommand
{
    public Car _car;

    public MoveBackwardCommand(Car car) => _car = car;

    /// <summary>
    /// Executes the move backward command.
    /// </summary>
    /// <returns>True if the move was completed successfully, otherwise false.</returns>
    public bool Execute()
    {
        var completed = _car.MoveBackward();
        if (completed) _car.Draw();
        return completed;
    }
}

