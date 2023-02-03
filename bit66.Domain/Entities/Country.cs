namespace bit66.Domain.Entities;

public class Country: EntityBase
{
    public string Name { get; set; } = null!;
    
    public ICollection<SoccerPlayer> Players { get; set; } = null!;
}