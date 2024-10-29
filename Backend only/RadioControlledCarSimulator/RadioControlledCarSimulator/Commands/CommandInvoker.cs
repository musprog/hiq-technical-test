using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Extensions;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Commands;
public static class CommandInvoker
{
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
