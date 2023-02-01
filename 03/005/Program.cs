WebApplicationOptions options = new()
{
    ContentRootPath = AppContext.BaseDirectory,
    Args = args
};
var builder = WebApplication.CreateBuilder(options);
builder.Host.UseWindowsService();

var app = builder.Build();

app.MapGet("/", () =>
{
    return "Hello World!";
});

app.Run();
