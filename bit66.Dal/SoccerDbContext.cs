using bit66.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace bit66.Dal;

public class SoccerDbContext: DbContext
{
    public SoccerDbContext(DbContextOptions<SoccerDbContext> options) :
        base(options)
    { }

    public DbSet<SoccerPlayer> Players { get; init; }
    public DbSet<Country> Countries { get; init; }
    public DbSet<Command> Commands { get; set; }
}