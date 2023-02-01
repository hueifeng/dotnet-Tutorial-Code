using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var loggerFactory = new ServiceCollection()
    .AddLogging(builder =>
                builder.AddSimpleConsole(options =>
                {
                    options.IncludeScopes = true;
                })
    )
    .BuildServiceProvider()
    .GetRequiredService<ILoggerFactory>();

var logger = loggerFactory.CreateLogger<Program>();
using (logger.BeginScope("Scope Id:{id}", Guid.NewGuid().ToString("N")))
{
    logger.LogInformation("start get");
    logger.LogInformation("result=1");
    logger.LogInformation("end get");
}

Console.ReadLine();