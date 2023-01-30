using bit66.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace bit66.Dal;

public class SoccerDbContext: DbContext
{
    public SoccerDbContext(DbContextOptions<SoccerDbContext> options) :
        base(options)
    { }

    private DbSet<SoccerPlayer> Players { get; init; }
}