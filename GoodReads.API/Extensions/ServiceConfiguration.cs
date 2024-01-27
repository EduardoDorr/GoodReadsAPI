using System.Text.Json.Serialization;

using Microsoft.OpenApi.Models;

using GoodReads.API.Middlewares;
using GoodReads.Application;
using GoodReads.Infrastructure;

namespace GoodReads.API.Extensions;

public static class ServiceConfiguration
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddInfrastructure(builder.Configuration)
                        .AddApplication()
                        .AddDomain();

        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddProblemDetails();

        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.WriteIndented = true;
        });

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "GoodReads.API",
                Version = "v1",
                Contact = new OpenApiContact
                {
                    Name = "Eduardo Dörr",
                    Email = "edudorr@hotmail.com",
                    Url = new Uri("https://github.com/EduardoDorr")
                }
            });
        });

        return builder;
    }
}