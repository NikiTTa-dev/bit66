using bit66.Domain.Interfaces.Services;
using bit66.Logic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace bit66.Logic;

public static class DependencyInjection
{
    public static IServiceCollection AddLogic(this IServiceCollection services)
    {
        services.AddScoped<ISoccerPlayerService, SoccerPlayerService>();
        services.AddScoped<ICommandService, CommandService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);

        return services;
    }
}