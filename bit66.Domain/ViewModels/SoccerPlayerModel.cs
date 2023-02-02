using System.ComponentModel.DataAnnotations;
using bit66.Domain.Attributes.Validation;

namespace bit66.Domain.ViewModels;

public class SoccerPlayerModel: ModelBase
{
    [Required]
    [MaxLength(30)]
    public string FirstName { get; set; } = null!;
    
    [Required]
    [MaxLength(30)]
    public string LastName { get; set; } = null!;
    
    [Required(ErrorMessage="Введите дату рождения")]
    [DateTimeMinValue(ErrorMessage = "Дата рождения должна быть раньше сегодняшнего дня")]
    public DateTime? BirthDate { get; set; }
    
    [Required]
    public CommandModel Command { get; set; } = null!;
    
    [Required]
    public CountryModel Country { get; set; } = null!;
}