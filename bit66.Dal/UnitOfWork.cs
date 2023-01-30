using bit66.Domain.Interfaces;
using bit66.Domain.Interfaces.Repository;

namespace bit66.Dal;

public class UnitOfWork: IUnitOfWork
{
    private readonly SoccerDbContext _context;
    public ISoccerRepository Players { get; }
    public ICountryRepository Countries { get; }
    public ICommandRepository Commands { get; }
    
    public UnitOfWork(
        SoccerDbContext context,
        ISoccerRepository players,
        ICountryRepository countries,
        ICommandRepository commands)
    {
        _context = context;
        Players = players;
        Countries = countries;
        Commands = commands;
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
    
    private bool _disposed;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}