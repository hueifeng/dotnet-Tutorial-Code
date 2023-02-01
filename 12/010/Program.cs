using _010;
using Microsoft.Extensions.Logging;

using ILoggerFactory loggerFactory =
    LoggerFactory.Create(builder =>
        builder.AddCustomFormatter(options =>
        {
            options.CustomPrefix = "<|";
            options.CustomSuffix = "|>";
        }));

ILogger<Program> logger = loggerFactory.CreateLogger<Program>();

logger.LogInformation("Hello World!");
Console.ReadLine();