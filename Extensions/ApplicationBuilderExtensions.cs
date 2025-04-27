using Ocelot.Middleware;

namespace Gateway.Extensions;

public static class ApplicationBuilderExtensions
{
    public static async Task<IApplicationBuilder> UseCustomMiddleware(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();
        app.UseCors("Default");

        await app.UseOcelot();

        return app;
    }
}

