using System.ComponentModel.DataAnnotations;

namespace bit66.Domain.Entities;

public class SoccerPlayer: EntityBase
{
    [MaxLength(30)]
    public string FirstName { get; set; } = null!;
    [MaxLength(30)]
    public string LastName { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public Command Command { get; set; } = null!;
    public Country Country { get; set; } = null!;
}