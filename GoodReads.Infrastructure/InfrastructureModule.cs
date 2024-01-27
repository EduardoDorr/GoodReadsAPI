using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using GoodReads.Core.Interfaces;
using GoodReads.Domain.Interfaces;
using GoodReads.Infrastructure.Persistences.Data;
using GoodReads.Infrastructure.Persistences.Repositories;

namespace GoodReads.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContexts(configuration)
                .AddRepositories()
                .AddUnitOfWork();

        return services;
    }

    private static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["DatabaseSettings:GoodReadsConnectionString"];

        services.AddDbContext<GoodReadsDbContext>(opts =>
                        opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IBookRepository, BookRepository>();
        services.AddTransient<IRatingRepository, RatingRepository>();

        return services;
    }

    private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        return services;
    }
}