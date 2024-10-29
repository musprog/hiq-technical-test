
using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Commands;
public class MoveBackwardCommand : ICommand
{
    public Car _car;
    public MoveBackwardCommand(Car car) => _car = car;
    public bool Execute()
    {
        var completed = _car.MoveBackward();
        if (completed) _car.Draw();
        return completed;
    }
        
}
