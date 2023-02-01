using _005;
using Microsoft.Extensions.Localization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization();
builder.Services.AddJsonLocalizer(builder.Environment.ContentRootFileProvider);

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
