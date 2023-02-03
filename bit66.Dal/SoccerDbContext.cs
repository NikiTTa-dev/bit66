using System.Reflection;
using bit66.Dal.Configurations;
using bit66.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace bit66.Dal;

public class SoccerDbContext: DbContext
{
    public SoccerDbContext(DbContextOptions<SoccerDbContext> options) :
        base(options)
    { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CommandConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        modelBuilder.ApplyConfiguration(new SoccerPlayerConfiguration());
        //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<Country> Countries { get; init; } = null!;
    public DbSet<Command> Commands { get; set; } = null!;
    public DbSet<SoccerPlayer> Players { get; init; } = null!;
}