using GoodReads.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

public static class DomainModule
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddServices();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IRatingService, RatingService>();

        return services;
    }
}