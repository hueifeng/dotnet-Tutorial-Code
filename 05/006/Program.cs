using _006;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

IConfiguration configuration = new ConfigurationBuilder()
           .AddJsonFile("person.json")
           .Build();
var services = new ServiceCollection();
//services.AddOptions<Persion>()
//    .Bind(configuration)
//    .ValidateDataAnnotations();
//var optionsBuilder = services.AddOptions<Persion>()
//    .Bind(configuration)
//    .ValidateDataAnnotations()
//    .Validate(config =>
//    {
//        if (config.Age < 19)
//            return false;
//        return true;
//    });

var optionsBuilder = services.AddOptions<Persion>()
    .Bind(configuration)
    .ValidateDataAnnotations()
    .Validate(config =>
    {
        if (config.Age < 19)
            return false;
        return true;
    }, "填写信息有误，年龄必须大于19岁。");


var person = services.BuildServiceProvider()
    .GetRequiredService<IOptions<Persion>>()
    .Value;
Console.WriteLine();