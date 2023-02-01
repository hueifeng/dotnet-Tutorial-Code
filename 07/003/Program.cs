using _003;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.UseMiddleware<CustomMiddleware>();

app.MapControllers();

app.Run();
