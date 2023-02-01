using _009;
using _010;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("person.json", true, true)
    .Build();
var services = new ServiceCollection();
var optionsSnapshot = services
    .AddOptions()
    .Configure<Person>(configuration)
    .AddSingleton<ConfigureReader>()
    .BuildServiceProvider(validateScopes: true)
    .GetRequiredService<ConfigureReader>();

