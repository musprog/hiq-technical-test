
using RadioControlledCarSimulator.Interface;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Commands;
public class MoveForwardCommand : ICommand
{
    private Car _car;
    public MoveForwardCommand(Car car) => _car = car;

    public void Execute() => _car.MoveForward();
}
