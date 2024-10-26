
using RadioControlledCarSimulator.Interface;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Commands;
public class MoveBackwardCommand : ICommand
{
    public Car _car;
    public MoveBackwardCommand(Car car) => _car = car;
    

    public void Execute()
    {
        throw new NotImplementedException();
    }
}
