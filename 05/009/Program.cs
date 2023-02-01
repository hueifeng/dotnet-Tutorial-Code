using _009;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("person.json")
    .Build();
var services = new ServiceCollection();
var serviceProvider = services
    .AddOptions()
    .Configure<Person>(configuration)
    .AddSingleton<IConfigureOptions<Person>>(new CountIncrement())
    .BuildServiceProvider();
Print(serviceProvider);
Print(serviceProvider);

static void Print(IServiceProvider provider)
{
    var scopedProvider = provider
        .GetRequiredService<IServiceScopeFactory>()
        .CreateScope()
        .ServiceProvider;
    var options = scopedProvider.GetRequiredService<IOptions<Person>>().Value;
    var optionsSnapshot1 = scopedProvider.GetRequiredService<IOptionsSnapshot<Person>>().Value;
    var optionsSnapshot2 = scopedProvider.GetRequiredService<IOptionsSnapshot<Person>>().Value;
    Console.WriteLine($"options:{options.Age}");
    Console.WriteLine($"optionsSnapshot1:{optionsSnapshot1.Age}");
    Console.WriteLine($"optionsSnapshot2:{optionsSnapshot2.Age}");
}

