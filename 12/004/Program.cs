using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var loggerFactory = new ServiceCollection()
    .AddLogging(builder =>
        builder.AddConsole()
            .SetMinimumLevel(LogLevel.Warning)
    )
    .BuildServiceProvider()
    .GetRequiredService<ILoggerFactory>();

var logger = loggerFactory.CreateLogger<Program>();
var simpleLogger = loggerFactory.CreateLogger<Simple>();

logger.LogInformation("This information log from Program");
logger.LogError("This error log from Program");
logger.LogWarning("This warning log from Program");
simpleLogger.LogInformation("This information log from Simple");
simpleLogger.LogError("This error log from Simple");
simpleLogger.LogWarning("This warning log from Program");
Console.ReadLine();