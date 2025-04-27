using Ocelot.DependencyInjection;

namespace Gateway.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        var allowedOrigins = configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddOcelot();

        services.AddCors(options =>
        {
            options.AddPolicy(
                "Default",
                policy => policy
                    .WithOrigins(allowedOrigins)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
            );
        });

        return services;
    }
}
