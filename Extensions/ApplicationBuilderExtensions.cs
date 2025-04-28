using Ocelot.Middleware;

namespace Gateway.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseCustomMiddleware(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerForOcelotUI(opt =>
        {
            opt.PathToSwaggerGenerator = "/swagger/docs"; // important!
        });

        app.UseHttpsRedirection();
        app.UseCors("Default");
        app.UseOcelot().Wait();

        return app;
    }
}