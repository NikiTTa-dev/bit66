namespace bit66.Domain.Entities;

public class SoccerPlayer: EntityBase
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public Command Command { get; set; } = null!;
    public Country Country { get; set; } = null!;
}