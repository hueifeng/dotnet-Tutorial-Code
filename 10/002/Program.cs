using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks()
    .AddCheck("default", Check);

var app = builder.Build();

app.UseHealthChecks("/health");

app.Run();

HealthCheckResult Check()
{
    var rnd = new Random().Next(1, 4);
    return rnd switch
    {
        1 => HealthCheckResult.Healthy(),
        2 => HealthCheckResult.Unhealthy(),
        _ => HealthCheckResult.Degraded()
    };
}
