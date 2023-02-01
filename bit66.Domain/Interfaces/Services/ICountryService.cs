using bit66.Domain.ViewModels;

namespace bit66.Domain.Interfaces.Services;

public interface ICountryService
{
    public Task<IEnumerable<CountryModel>> GetCountriesAsync();
}