using _007;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new RedisFileProvider(Options.Create(new RedisFileOptions
    {
        HostAndPort = "localhost:6379"
    }))
});

app.UseDirectoryBrowser(new DirectoryBrowserOptions
{
    FileProvider = new RedisFileProvider(Options.Create(new RedisFileOptions
    {
        HostAndPort = "localhost:6379"
    }))
});

app.Run();
