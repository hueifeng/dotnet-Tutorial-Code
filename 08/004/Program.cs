using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;

var cache = new ServiceCollection()
    .AddDistributedSqlServerCache(options =>
    {
        options.ConnectionString = "data source=.;integrated security=True;User ID=sa;initial catalog=TestDb;Password=sa;";
        options.SchemaName = "dbo";
        options.TableName = "AspNetCache";
    }).BuildServiceProvider()
    .GetRequiredService<IDistributedCache>();
cache.SetString("key", "value", new DistributedCacheEntryOptions
{
    AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(20)
});
