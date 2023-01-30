using bit66.Domain.Enums;

namespace bit66.Domain.Entities;

public class Country: EntityBase
{
    public CountryNames Name { get; set; }
}