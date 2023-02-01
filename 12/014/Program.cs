using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var logger = new ServiceCollection()
    .AddLogging(builder =>
        builder
            .AddEventSourceLogger())
    .BuildServiceProvider()
    .GetRequiredService<ILoggerFactory>()
    .CreateLogger<Program>();

logger.LogInformation("Information...");
logger.LogWarning("Warning...");
logger.LogError("Error...");
