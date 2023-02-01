using AutoMapper;
using bit66.Domain.Entities;
using bit66.Domain.ViewModels;

namespace bit66.Logic.Profiles;

public class CountryMapperConfiguration: Profile
{
    public CountryMapperConfiguration()
    {
        CreateMap<Country, CountryModel>();
        CreateMap<CountryModel, Country>();
    }
}