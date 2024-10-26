using RadioControlledCarSimulator.Interface;
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Commands;
public class TurnRightCommand : ICommand
{
    private Car _car;
    public TurnRightCommand(Car car) => _car = car;

    public void Execute()
    {
        throw new NotImplementedException();
    }

    //To do call turn right 
}
