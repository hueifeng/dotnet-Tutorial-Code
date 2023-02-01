using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

var firstSwitch = new SourceSwitch("FirstSwitch")
{
    Level = SourceLevels.All
};
var logger = new ServiceCollection()
    .AddLogging(builder =>
        builder
            .AddTraceSource(firstSwitch, new ConsoleTraceListener()))
    .BuildServiceProvider()
    .GetRequiredService<ILoggerFactory>()
    .CreateLogger<Program>();
logger.LogInformation("Information...");
logger.LogWarning("Warning...");
logger.LogError("Error...");
Console.ReadLine();