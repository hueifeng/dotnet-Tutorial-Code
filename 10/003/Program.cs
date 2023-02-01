using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks()
    .AddCheck("default", Check);

var app = builder.Build();
var options = new HealthCheckOptions
{
    ResultStatusCodes =
    {
        [HealthStatus.Unhealthy] = 420,
        [HealthStatus.Healthy] = 298,
        [HealthStatus.Degraded] = 299
    }
};

app.UseHealthChecks("/health", options);

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
