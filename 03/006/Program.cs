using _006;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseWindowsForms<Form1>();

var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.RunAsync();
