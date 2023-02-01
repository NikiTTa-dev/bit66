using AutoMapper;
using bit66.Domain.Entities;
using bit66.Domain.ViewModels;

namespace bit66.Logic.Profiles;

public class PlayerMapperConfiguration: Profile
{
    public PlayerMapperConfiguration()
    {
        CreateMap<SoccerPlayer, SoccerPlayerModel>();
        CreateMap<SoccerPlayerModel, SoccerPlayer>();
    }
}