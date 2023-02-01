using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

var cache = new ServiceCollection()
    .AddMemoryCache()
    .BuildServiceProvider()
    .GetRequiredService<IMemoryCache>();

cache.Set("m1", "dotnet");
cache.TryGetValue("m1", out var value);
Console.WriteLine(value);
