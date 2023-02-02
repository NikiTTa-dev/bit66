using bit66.Domain.Interfaces.Services;
using bit66.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bit66.App.Pages;

public class IndexModel : PageModel
{
    public ICommandService CommandService { get; }
    public ICountryService CountryService { get; }
    public ISoccerPlayerService PlayerService { get; }

    public IndexModel(
        ISoccerPlayerService playerService,
        ICommandService commandService,
        ICountryService countryService)
    {
        CommandService = commandService;
        CountryService = countryService;
        PlayerService = playerService;
    }

    public async Task<IActionResult> OnPostAsync(SoccerPlayerModel playerModel)
    {
        if (!ModelState.IsValid)
            return Page();

        await PlayerService.EditPlayerAsync(playerModel);

        return Page();
    }
}