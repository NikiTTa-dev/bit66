using bit66.Domain.Entities;
using bit66.Domain.Interfaces.Repository;

namespace bit66.Dal.Repositories;

public class SoccerRepository:GenericRepository<SoccerPlayer>, ISoccerRepository
{
    public SoccerRepository(SoccerDbContext context): base(context)
    {
    }
}