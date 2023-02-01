using App3;
using App4;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Localization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost";
});
builder.Services.AddLocalization();
builder.Services.AddJsonLocalizer(builder.Environment.ContentRootFileProvider,
    builder.Services.BuildServiceProvider().GetRequiredService<IDistributedCache>());

var app = builder.Build();

app.UseRequestLocalization(options =>
{
    options
        .AddSupportedCultures("en-US", "zh-CN")
        .AddSupportedUICultures("en-US", "zh-CN");
});


app.MapGet("/", (IStringLocalizer<SharedResource> localizer) =>
{
    return Results.Content(localizer.GetString("Message").Value);
});

app.Run();
