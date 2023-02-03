using System.ComponentModel.DataAnnotations;

namespace bit66.Domain.Entities;

public class Country: EntityBase
{
    public string Name { get; set; } = null!;
}