﻿using bit66.Dal.Repositories;
using bit66.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace bit66.Dal;

public static class DependencyInjection
{
    public static IServiceCollection AddDal(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<SoccerDbContext>(options=>
            options.UseSqlite(connectionString));
        services.AddScoped<ISoccerRepository, SoccerRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<ICommandRepository, CommandRepository>();
        
        return services;
    }
}