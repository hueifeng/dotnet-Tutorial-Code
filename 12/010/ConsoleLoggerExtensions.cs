using Microsoft.Extensions.Logging;

namespace _010
{
    public static class ConsoleLoggerExtensions
    {
        public static ILoggingBuilder AddCustomFormatter(this ILoggingBuilder builder,
         Action<CustomOptions> configure)
        {
            return builder.AddConsole(options => options.FormatterName = "customName")
                .AddConsoleFormatter<CustomFormatter, CustomOptions>(configure);
        }
    }

}
