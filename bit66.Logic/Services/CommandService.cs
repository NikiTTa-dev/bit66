using AutoMapper;
using bit66.Domain.Interfaces;
using bit66.Domain.Interfaces.Services;
using bit66.Domain.ViewModels;

namespace bit66.Logic.Services;

public class CommandService: ICommandService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CommandService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<CommandModel>> GetCommandsAsync()
    {
        var commands = await _unitOfWork.Commands.GetAllAsync();
        return commands.Select(c=> _mapper.Map<CommandModel>(c));
    }
}