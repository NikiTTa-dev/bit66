using bit66.Domain.Entities;

namespace bit66.Domain.Interfaces.Repository;

public interface ISoccerRepository: IGenericRepository<SoccerPlayer>
{
    public Task<IEnumerable<SoccerPlayer>> GetAllPlayersWithCountryAndCommandAsync();
    public Task<SoccerPlayer?> FindWithCommandAndCountryAsync(int id);
}