using Microsoft.Extensions.Configuration;

IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

var defaultConnection = configuration
.GetValue<string>("ConnectionStrings:DefaultConnection");
var connectionString = configuration.GetConnectionString("DefaultConnection");
configuration["ConnectionStrings:DefaultConnection"] = "new connectionn-string";
var newConnectionString = configuration
.GetValue<string>("ConnectionStrings:DefaultConnection");

Console.WriteLine($"GetValue: {defaultConnection}");
Console.WriteLine($"GetConnectionString: {connectionString}");
Console.WriteLine($"newConnectionString: { newConnectionString}");

