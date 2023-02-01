using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var logger = new ServiceCollection()
    .AddLogging(builder =>
        builder.AddConsole())
    .BuildServiceProvider()
    .GetRequiredService<ILoggerFactory>()
    .CreateLogger<Program>();

logger.LogInformation("This information log from Program");
logger.LogError("This error log from Program");
logger.LogCritical("This critical log from Program");
logger.LogWarning("This warning log from Program");

logger.LogInformation(ApplicationEvents.Create, "订单创建");
logger.LogInformation(ApplicationEvents.Delete, "订单删除，订单编号：{0}", "NO.10000000");
logger.LogInformation(ApplicationEvents.Read, "读取订单信息");
logger.LogInformation(ApplicationEvents.Update, "修改了订单的配送地址：从“{0}”修改到“{1}”", "A小区", "B小区");

internal static class ApplicationEvents
{
    internal const int Create = 1000;
    internal const int Read = 1001;
    internal const int Update = 1002;
    internal const int Delete = 1003;
}
