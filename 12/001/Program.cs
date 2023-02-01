using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var logger = new ServiceCollection()
    .AddLogging(builder =>
        builder.AddConsole())
    .BuildServiceProvider()
    .GetRequiredService<ILoggerFactory>()
    .CreateLogger<Program>();
var levels = Enum.GetValues<LogLevel>()
    .Where(l => l != LogLevel.None);
var eventId = 1;

foreach (var level in levels)
{
    logger.Log(level, eventId++, "LogLevel:{0}", level);
}
Console.ReadLine();