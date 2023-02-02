using bit66.Domain.Interfaces.Services;
using bit66.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bit66.App.Pages;

public class AddPlayer : PageModel
{
    private ISoccerPlayerService _playerService;
    public ICommandService CommandService { get; }
    public ICountryService CountryService { get; }

    [BindProperty]
    public SoccerPlayerModel PlayerModel { get; set; } = null!;
    
    public AddPlayer(
        ISoccerPlayerService playerService,
        ICommandService commandService,
        ICountryService countryService)
    {
        _playerService = playerService;
        CommandService = commandService;
        CountryService = countryService;
        
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        await _playerService.AddPlayerAsync(PlayerModel);

        return Page();
    }
}