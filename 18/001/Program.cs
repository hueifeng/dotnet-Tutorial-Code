using System.Runtime.InteropServices;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () =>
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"系统架构：{RuntimeInformation.OSArchitecture}");
        sb.AppendLine($"系统名称：{RuntimeInformation.OSDescription}");
        sb.AppendLine($"进程架构：{RuntimeInformation.ProcessArchitecture}");
        sb.AppendLine($"是否64位操作系统：{Environment.Is64BitOperatingSystem}");
        return sb.ToString();
    })
    .WithName("GetInfo");

app.Run("http://*:5000");