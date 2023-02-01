using bit66.Domain.Entities;
using bit66.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace bit66.Dal.Repositories;

public class SoccerRepository : GenericRepository<SoccerPlayer>, ISoccerRepository
{
    private readonly SoccerDbContext _context;

    public SoccerRepository(SoccerDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SoccerPlayer>> GetAllPlayersWithCountryAndCommandAsync()
    {
        return await _context.Players
            .Include(p => p.Command)
            .Include(p => p.Country)
            .ToListAsync();
    }

    public async Task<SoccerPlayer?> FindWithCommandAndCountryAsync(int id)
    {
        return await _context.Players
            .Include(p => p.Command)
            .Include(p => p.Country)
            .FirstOrDefaultAsync(p=>p.Id==id);
    }
}