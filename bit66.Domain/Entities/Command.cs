using System.ComponentModel.DataAnnotations;

namespace bit66.Domain.Entities;

public class Command: EntityBase
{
    [MaxLength(30)]
    public string Name { get; set; } = null!;
}