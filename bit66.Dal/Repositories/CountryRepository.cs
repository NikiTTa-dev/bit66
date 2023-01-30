using bit66.Domain.Entities;
using bit66.Domain.Interfaces.Repository;

namespace bit66.Dal.Repositories;

public class CountryRepository: ICountryRepository
{
    private SoccerDbContext _context;

    public CountryRepository(SoccerDbContext context)
    {
        _context = context;
    }

    public Task<Country> FindAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Country entity)
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
}