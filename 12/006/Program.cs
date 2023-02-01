using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.Development.json")
    .Build();

var loggerFactory = new ServiceCollection()
    .AddLogging(builder =>
        builder.AddConsole()
            .AddConfiguration(configuration.GetSection("Logging"))
    )
    .BuildServiceProvider()
    .GetRequiredService<ILoggerFactory>();

var logger = loggerFactory.CreateLogger<Program>();
logger.LogInformation("This information log from Program");
logger.LogError("This error log from Program");
logger.LogWarning("This warning log from Program");

using (logger.BeginScope("Scope Id:{id}", Guid.NewGuid().ToString("N")))
{
    logger.LogWarning("start get");
    logger.LogWarning("result=1");
    logger.LogWarning("end get");
}

Console.ReadLine();