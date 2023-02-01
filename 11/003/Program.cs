var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

const string cacheMaxAge = "604800";
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append(
            "Cache-Control", $"public, max-age={cacheMaxAge}");
    }
});

app.Run();
