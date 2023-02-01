using AutoMapper;
using bit66.Domain.Interfaces;
using bit66.Domain.Interfaces.Services;
using bit66.Domain.ViewModels;

namespace bit66.Logic.Services;

public class CountryService: ICountryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CountryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CountryModel>> GetCountriesAsync()
    {
        var countries = await _unitOfWork.Countries.GetAllAsync();
        return countries.Select(c=> _mapper.Map<CountryModel>(c));
    }
}