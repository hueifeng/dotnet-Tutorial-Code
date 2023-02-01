using _005;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Services.AddHealthChecks()
    .AddCheck("Foo", Check)
    .AddCheck("Bar", Check)
    .AddCheck("Baz", Check);

builder.Services.Configure<HealthCheckPublisherOptions>(options =>
{
    options.Delay = TimeSpan.FromSeconds(2);
    options.Period = TimeSpan.FromSeconds(5);
});
builder.Services.AddSingleton<IHealthCheckPublisher, SimplePublisher>();

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
