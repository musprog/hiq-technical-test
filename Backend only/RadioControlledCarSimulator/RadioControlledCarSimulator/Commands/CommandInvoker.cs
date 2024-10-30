using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Extensions;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Commands;

/// <summary>
/// The CommandInvoker class is responsible for invoking the appropriate command based on the given input.
/// </summary>
public static class CommandInvoker
{
    /// <summary>
    /// Invokes the command based on the given input.
    /// </summary>
    /// <param name="command">The input command.</param>
    /// <param name="car">The car object.</param>
    /// <returns>The invoked command.</returns>
    public static ICommand InvokeCommand(string command, Car car)
    {
        ICommand toCommand = command switch
        {
            "F" => new MoveForwardCommand(car),
            "B" => new MoveBackwardCommand(car),
            "L" => new TurnLeftCommand(car),
            "R" => new TurnRightCommand(car),
            _ => throw new SimulationException("Invalid command!")
        };
        return toCommand;
    }
}
