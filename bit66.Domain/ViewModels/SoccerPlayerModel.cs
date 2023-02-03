using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using bit66.Domain.Attributes.Validation;

namespace bit66.Domain.ViewModels;

public class SoccerPlayerModel: ModelBase
{
    [Required(ErrorMessage="Введите имя игрока")]
    [MaxLength(30)]
    [DisplayName("Имя")]
    public string FirstName { get; set; } = null!;
    
    [Required(ErrorMessage="Введите фамилию игрока")]
    [MaxLength(30)]
    [DisplayName("Фамилия")]
    public string LastName { get; set; } = null!;
    
    [Required(ErrorMessage="Введите дату рождения")]
    [DateTimeMinValue(ErrorMessage = "Дата рождения должна быть раньше сегодняшнего дня")]
    [DisplayName("Дата рождения")]
    public DateTime? BirthDate { get; set; }

    [Required(ErrorMessage="Выберите пол")]
    [DisplayName("Пол")]
    public string Gender { get; set; } = null!;
    
    [Required]
    public CommandModel Command { get; set; } = null!;
    
    [Required]
    public CountryModel Country { get; set; } = null!;
}