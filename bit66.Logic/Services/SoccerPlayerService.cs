using AutoMapper;
using bit66.Domain.Entities;
using bit66.Domain.Interfaces;
using bit66.Domain.Interfaces.Services;
using bit66.Domain.ViewModels;

namespace bit66.Logic.Services;

public class SoccerPlayerService : ISoccerPlayerService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SoccerPlayerService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SoccerPlayerModel>> GetAllPlayers()
    {
        return (await _unitOfWork.Players.GetAllPlayersWithCountryAndCommandAsync())
                .Select(p =>
                _mapper.Map<SoccerPlayerModel>(p));
    }

    public async Task AddPlayerAsync(SoccerPlayerModel player)
    {
        var playerEntity = _mapper.Map<SoccerPlayer>(player);

        if (await _unitOfWork.Commands.FindByNameAsync(playerEntity.Command.Name) is not { } command)
        {
            _unitOfWork.Commands.Add(playerEntity.Command);
            await _unitOfWork.SaveChangesAsync();
            command = (await _unitOfWork.Commands.FindByNameAsync(playerEntity.Command.Name))!;
        }

        playerEntity.Command = command;

        if (await _unitOfWork.Countries.FindByNameAsync(playerEntity.Country.Name) is not { } country)
        {
            _unitOfWork.Countries.Add(playerEntity.Country);
            await _unitOfWork.SaveChangesAsync();
            country = (await _unitOfWork.Countries.FindByNameAsync(playerEntity.Country.Name))!;
        }

        playerEntity.Country = country;

        _unitOfWork.Players.Add(playerEntity);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<SoccerPlayerModel> EditPlayerAsync(SoccerPlayerModel player)
    {
        var soccerPlayer = _mapper.Map<SoccerPlayer>(player);
        if (await _unitOfWork.Players.FindWithCommandAndCountryAsync(soccerPlayer.Id) is not { } playerEntity)
            throw new Exception("Player doesn't exist.");

        if (await _unitOfWork.Commands.FindByNameAsync(soccerPlayer.Command.Name) is not { } command)
        {
            _unitOfWork.Commands.Add(soccerPlayer.Command);
            await _unitOfWork.SaveChangesAsync();
            command = (await _unitOfWork.Commands.FindByNameAsync(soccerPlayer.Command.Name))!;
        }

        playerEntity.Command = command;

        if (await _unitOfWork.Countries.FindByNameAsync(soccerPlayer.Country.Name) is not { } country)
        {
            _unitOfWork.Countries.Add(soccerPlayer.Country);
            await _unitOfWork.SaveChangesAsync();
            country = (await _unitOfWork.Countries.FindByNameAsync(soccerPlayer.Country.Name))!;
        }

        playerEntity.Country = country;

        playerEntity.FirstName = player.FirstName;
        playerEntity.LastName = player.LastName;
        playerEntity.BirthDate = player.BirthDate;
        playerEntity.Gender = player.Gender;

        _unitOfWork.Players.Update(playerEntity);
        await _unitOfWork.SaveChangesAsync();

        return _mapper.Map<SoccerPlayerModel>(playerEntity);
    }
}