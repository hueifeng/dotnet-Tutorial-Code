using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using System.Net.Mime;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks()
    .AddCheck("Foo", Check)
    .AddCheck("Bar", Check)
    .AddCheck("Baz", Check);

var app = builder.Build();
var options = new HealthCheckOptions
{
    ResponseWriter = ReportAsync
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

static Task ReportAsync(HttpContext context, HealthReport report)
{
    var result = JsonConvert.SerializeObject(
        new
        {
            status = report.Status.ToString(),
            responseTimeStamp =
new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
            errors = report.Entries.Select(e => new {
                key = e.Key,
                value
= Enum.GetName(typeof(HealthStatus), e.Value.Status)
            })
        });
    context.Response.ContentType = MediaTypeNames.Application.Json;
    return context.Response.WriteAsync(result);
}
