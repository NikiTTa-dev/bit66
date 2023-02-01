using bit66.Domain.ViewModels;

namespace bit66.Domain.Interfaces.Services;

public interface ICommandService
{
    public Task<IEnumerable<CommandModel>> GetCommandsAsync();
}