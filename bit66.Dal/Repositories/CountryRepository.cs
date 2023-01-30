using bit66.Domain.Entities;
using bit66.Domain.Interfaces.Repository;

namespace bit66.Dal.Repositories;

public class CountryRepository: GenericRepository<Country>,ICountryRepository
{
    public CountryRepository(SoccerDbContext context): base(context)
    {
    }
}