
using RadioControlledCarSimulator.Interface;

namespace RadioControlledCarSimulator.Commands;
public class CommandHandler
{
    private ICommand? _command;

    public Task SetCommand(ICommand command)
    {
        _command = command;
        return Task.CompletedTask;
    }

    public Task ExcuteCommand()
    {
        _command.Execute();
        return Task.CompletedTask;
    }

}
