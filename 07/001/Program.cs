using _001;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
app.UseCustomExtension();

app.MapGet("/", () =>
{
    return "Hello World!";
});

app.Run();