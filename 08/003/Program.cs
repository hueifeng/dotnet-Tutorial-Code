using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;

var cache = new ServiceCollection()
    .AddStackExchangeRedisCache(options =>
    {
        options.Configuration = "localhost";
    }).BuildServiceProvider()
    .GetRequiredService<IDistributedCache>();
cache.SetString("key1", "value", new DistributedCacheEntryOptions
{
    AbsoluteExpiration = DateTimeOffset.UtcNow.AddSeconds(30),
    SlidingExpiration = TimeSpan.FromSeconds(10)
});
var value = cache.GetString("key1");
