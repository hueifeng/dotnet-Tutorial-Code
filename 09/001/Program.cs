using Microsoft.Extensions.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization();

var app = builder.Build();

app.MapGet("/", (string? culture, IStringLocalizerFactory localizerFactory) =>
{
    var localizer = localizerFactory.Create("SharedResource", "app");
    if (!string.IsNullOrEmpty(culture))
    {
        CultureInfo.CurrentCulture = CultureInfo.CurrentUICulture = new CultureInfo(culture);
    }
    return Results.Content(localizer.GetString("Message").Value);
});

await app.RunAsync();
