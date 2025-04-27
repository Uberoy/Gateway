using Gateway.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Host (server) settings
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Configure(builder.Configuration.GetSection("Kestrel"));
});

// Register services
builder.Services.AddCustomServices(builder.Configuration);
builder.Configuration
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();


var app = builder.Build();

// Configure middleware
await app.UseCustomMiddleware();
app.Run();