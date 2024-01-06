using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using GoodReads.Domain.Interfaces;
using GoodReads.Infrastructure.Data;
using GoodReads.Infrastructure.Repositories;

namespace GoodReads.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositories()
                .AddDbContexts(configuration);

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IBookRepository, BookRepository>();
        services.AddTransient<IRatingRepository, RatingRepository>();

        return services;
    }

    private static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["DatabaseSettings:GoodReadsConnectionString"];

        services.AddDbContext<GoodReadsDbContext>(opts =>
                        opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        return services;
    }
}