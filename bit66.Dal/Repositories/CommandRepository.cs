using bit66.Domain.Entities;
using bit66.Domain.Interfaces.Repository;

namespace bit66.Dal.Repositories;

public class CommandRepository: GenericRepository<Command>, ICommandRepository
{
    public CommandRepository(SoccerDbContext context): base(context)
    {
    }
}