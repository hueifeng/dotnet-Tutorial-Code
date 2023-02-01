using System.Runtime.InteropServices;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () =>
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"ϵͳ�ܹ���{RuntimeInformation.OSArchitecture}");
        sb.AppendLine($"ϵͳ���ƣ�{RuntimeInformation.OSDescription}");
        sb.AppendLine($"���̼ܹ���{RuntimeInformation.ProcessArchitecture}");
        sb.AppendLine($"�Ƿ�64λ����ϵͳ��{Environment.Is64BitOperatingSystem}");
        return sb.ToString();
    })
    .WithName("GetInfo");

app.Run("http://*:5000");