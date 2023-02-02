using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bit66.Domain.ViewModels;

public class CommandModel: ModelBase
{
    [Required]
    [MaxLength(30)]
    [DisplayName("Command")]
    public string Name { get; set; } = null!;
}