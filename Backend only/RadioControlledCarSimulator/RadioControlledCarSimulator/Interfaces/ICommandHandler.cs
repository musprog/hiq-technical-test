
using RadioControlledCarSimulator.Models;

namespace RadioControlledCarSimulator.Interfaces
{
    public interface ICommandHandler
    {
        Task SetCommandAsync(ICommand command);

        Task<bool> ExecuteCommandsAsync();
    }
}
