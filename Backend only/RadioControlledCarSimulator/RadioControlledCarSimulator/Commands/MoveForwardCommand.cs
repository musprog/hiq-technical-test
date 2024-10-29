
using RadioControlledCarSimulator.Interfaces;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Commands;
public class MoveForwardCommand : ICommand
{
    private readonly Car _car;
    public MoveForwardCommand(Car car) => _car = car;
    public bool Execute()
    {
        var compeletd = _car.MoveForward();
        if (compeletd) _car.Draw();
        return compeletd;
    }
}
