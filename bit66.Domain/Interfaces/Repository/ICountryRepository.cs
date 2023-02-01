using bit66.Domain.Entities;

namespace bit66.Domain.Interfaces.Repository;

public interface ICountryRepository: IGenericRepository<Country>
{
    public Task<Country?> FindByNameAsync(string name);
}