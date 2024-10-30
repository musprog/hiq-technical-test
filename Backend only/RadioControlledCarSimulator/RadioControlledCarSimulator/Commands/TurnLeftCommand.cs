using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Commands;
public class TurnLeftCommand : ICommand
{
    private readonly Car _car;
    public TurnLeftCommand(Car car) => _car = car;
    public bool Execute()
    {
        var completed = _car.TurnLeft();
        if (completed) _car.Draw();
        return completed;
    }
}
