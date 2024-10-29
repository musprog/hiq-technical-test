using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Commands;
public class TurnRightCommand : ICommand
{
    private readonly Car _car;
    public TurnRightCommand(Car car) => _car = car;
    public bool Execute()
    {
        var completed = _car.TurnRight();
        if (completed) _car.Draw();
        return completed;
    }
}
