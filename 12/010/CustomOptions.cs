using Microsoft.Extensions.Logging.Console;

namespace _010
{
    public class CustomOptions : ConsoleFormatterOptions
    {
        public string CustomPrefix { get; set; }
        public string CustomSuffix { get; set; }

    }
}
