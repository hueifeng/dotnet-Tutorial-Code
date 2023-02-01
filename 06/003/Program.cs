using Hangfire;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
//ע��Hangfire���ݿ�־÷���
builder.Services.AddHangfire(x =>
        x.UseSqlServerStorage
(@"Server=.\;Database=Hangfire.Sample;Trusted_Connection=True;"));
//ע��Hangfire���ķ���
builder.Services.AddHangfireServer();

var app = builder.Build();
//����Hangfire���
app.UseHangfireDashboard();

app.UseAuthorization();
app.MapControllers();
app.Run();

RecurringJob.AddOrUpdate("����������", () =>
        Console.WriteLine($"����������{DateTime.Now.ToLongTimeString()}"), Cron.Minutely);
