using bit66.Domain.Entities;

namespace bit66.Domain.Interfaces.Repository;

public interface ICommandRepository: IGenericRepository<Command>
{
    public Task<Command?> FindByNameAsync(string name);
}