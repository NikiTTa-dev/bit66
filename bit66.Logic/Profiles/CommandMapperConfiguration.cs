using AutoMapper;
using bit66.Domain.Entities;
using bit66.Domain.ViewModels;

namespace bit66.Logic.Profiles;

public class CommandMapperConfiguration: Profile
{
    public CommandMapperConfiguration()
    {
        CreateMap<Command, CommandModel>();
        CreateMap<CommandModel, Command>();
    }
}