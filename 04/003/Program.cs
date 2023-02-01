using _003;

var builder = WebApplication.CreateBuilder(args);
//ЗўЮёзЂВс
builder.Services.AddTransient<ISampleTransient, Sample>();
builder.Services.AddScoped<ISampleScoped, Sample>();
builder.Services.AddSingleton<ISampleSingleton, Sample>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();