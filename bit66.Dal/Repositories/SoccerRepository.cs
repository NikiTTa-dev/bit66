using bit66.Domain.Entities;
using bit66.Domain.Interfaces.Repository;

namespace bit66.Dal.Repositories;

public class SoccerRepository: ISoccerRepository, IDisposable
{
    private SoccerDbContext _context;
    
    public SoccerRepository(SoccerDbContext context)
    {
        _context = context;
    }
    
    public async Task<SoccerPlayer> FindAsync(int id)
    {
        if (id == 1)
            return new SoccerPlayer();
        return null;
    }

    public Task AddAsync(SoccerPlayer entity)
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
    
    private bool _disposed = false;

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