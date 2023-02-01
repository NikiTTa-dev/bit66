using bit66.Domain.Entities;
using bit66.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace bit66.Dal.Repositories;

public class CountryRepository: GenericRepository<Country>,ICountryRepository
{
    private readonly SoccerDbContext _context;

    public CountryRepository(SoccerDbContext context): base(context)
    {
        _context = context;
    }

    public async Task<Country?> FindByNameAsync(string name)
    {
        return await _context.Countries.SingleOrDefaultAsync(c=>c.Name == name);
    }
}