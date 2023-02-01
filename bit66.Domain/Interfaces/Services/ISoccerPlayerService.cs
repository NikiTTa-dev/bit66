using bit66.Domain.ViewModels;

namespace bit66.Domain.Interfaces.Services;

public interface ISoccerPlayerService
{
    public Task AddPlayerAsync(SoccerPlayerModel player);
    public Task<SoccerPlayerModel> EditPlayerAsync(SoccerPlayerModel player);
}