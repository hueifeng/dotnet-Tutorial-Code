using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.CommandLine;

//IConfiguration configuration = new ConfigurationBuilder()
//            .AddCommandLine(args)
//            .Build();
//Console.WriteLine($"os：{configuration["os"]}");
//Console.WriteLine($"framework：{configuration["f"]}");
//Console.ReadLine();

var mapping = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
{
    { "-os", "windows" },
    { "--f", "net471" },
};

var configuration = new ConfigurationBuilder()
    .AddCommandLine(args, mapping)
    .Build();
Console.WriteLine($"os：{configuration["os"]}");
Console.WriteLine($"framework：{configuration["f"]}");
