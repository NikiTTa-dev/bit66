using bit66.Domain.Entities;
using bit66.Domain.Interfaces.Repository;

namespace bit66.Dal.Repositories;

public class CommandRepository: ICommandRepository
{
    private SoccerDbContext _context;

    public CommandRepository(SoccerDbContext context)
    {
        _context = context;
    }

    public Task<Command> FindAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Command entity)
    {
        throw new NotImplementedException();
    }

    public Task EditAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task SaveAsync()
    {
        throw new NotImplementedException();
    }
}