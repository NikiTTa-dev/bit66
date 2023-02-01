using bit66.Domain.Entities;
using bit66.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace bit66.Dal.Repositories;

public class CommandRepository: GenericRepository<Command>, ICommandRepository
{
    private readonly SoccerDbContext _context;

    public CommandRepository(SoccerDbContext context): base(context)
    {
        _context = context;
    }

    public async Task<Command?> FindByNameAsync(string name)
    {
        return await _context.Commands.SingleOrDefaultAsync(c=>c.Name == name);
    }
}