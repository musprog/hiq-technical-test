
using RadioControlledCarSimulator.Interface;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Commands;
public class TurnLeftCommand : ICommand
{
    private Car _car;

    public TurnLeftCommand(Car car) => _car = car;

    public void Execute()
    {
        throw new NotImplementedException();
    }
}
