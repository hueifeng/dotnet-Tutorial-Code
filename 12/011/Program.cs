using Microsoft.Extensions.Logging;

var loggerFactory = LoggerFactory.Create(
    builder => builder.AddConsole());
var logger = loggerFactory.CreateLogger<Program>();

logger.SayHello("HueiFeng");
Console.ReadLine();

public static partial class Log
{
    [LoggerMessageAttribute(EventId = 0, Level = LogLevel.Information, Message = "Hello {Name}")]
    public static partial void SayHello(this ILogger logger, string name);
}
