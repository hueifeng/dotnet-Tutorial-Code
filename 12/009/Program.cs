using Microsoft.Extensions.Logging;
using System.Text.Json;

using ILoggerFactory loggerFactory =
    LoggerFactory.Create(builder =>
        builder.AddJsonConsole(options =>
        {
            options.TimestampFormat = "hh:mm:ss ";
            options.JsonWriterOptions = new JsonWriterOptions
            {
                Indented = true
            };
        }));

ILogger<Program> logger = loggerFactory.CreateLogger<Program>();

logger.LogInformation("Hello World!");
Console.ReadLine();