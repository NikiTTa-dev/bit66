namespace bit66.Domain.Entities;

public class Command: EntityBase
{
    public string Name { get; set; } = null!;

    public ICollection<SoccerPlayer> Players { get; set; } = null!;
}