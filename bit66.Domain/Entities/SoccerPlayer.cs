namespace bit66.Domain.Entities;

public class SoccerPlayer: EntityBase
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime? BirthDate { get; set; }
    public string Gender { get; set; } = null!;
    public Command Command { get; set; } = null!;
    public Country Country { get; set; } = null!;
}