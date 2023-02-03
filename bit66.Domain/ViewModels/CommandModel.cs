using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bit66.Domain.ViewModels;

public class CommandModel: ModelBase
{
    [Required(ErrorMessage="Введите имя команды")]
    [MaxLength(30)]
    [DisplayName("Команда")]
    public string Name { get; set; } = null!;
}