using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bit66.Domain.ViewModels;

public class CountryModel: ModelBase
{
    [Required(ErrorMessage="Выберите страну")]
    [MaxLength(30)]
    [DisplayName("Страна")]
    public string Name { get; set; } = null!;
}