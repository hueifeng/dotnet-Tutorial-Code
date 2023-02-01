using Microsoft.Extensions.Localization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization();

var app = builder.Build();

app.UseRequestLocalization(options => options
    .AddSupportedCultures("en", "zh")
.AddSupportedUICultures("en", "zh"));

app.MapGet("/", (IStringLocalizerFactory localizerFactory) =>
{
    var localizer = localizerFactory.Create("SharedResource", "App");
    return Results.Content(localizer.GetString("Message").Value);
});


await app.RunAsync();
