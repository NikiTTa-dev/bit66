using System.ComponentModel.DataAnnotations;

namespace bit66.Domain.ViewModels;

public class CommandModel: ModelBase
{
    [Required]
    [MaxLength(30)]
    public string Name { get; set; } = null!;
}