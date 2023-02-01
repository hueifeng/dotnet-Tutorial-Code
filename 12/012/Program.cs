using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var logger = new ServiceCollection()
    .AddLogging(builder =>
        builder.AddConsole()
            .AddDebug()
            .SetMinimumLevel(LogLevel.Trace))
    .BuildServiceProvider()
    .GetRequiredService<ILoggerFactory>()
    .CreateLogger<Program>();

logger.LogTrace("Trace...");
logger.LogDebug("Debug...");
logger.LogInformation("Information...");
logger.LogWarning("Warning...");
logger.LogError("Error...");
logger.LogCritical("Critical...");
