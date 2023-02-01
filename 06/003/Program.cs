using Hangfire;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
//注册Hangfire数据库持久服务
builder.Services.AddHangfire(x =>
        x.UseSqlServerStorage
(@"Server=.\;Database=Hangfire.Sample;Trusted_Connection=True;"));
//注册Hangfire核心服务
builder.Services.AddHangfireServer();

var app = builder.Build();
//启动Hangfire面板
app.UseHangfireDashboard();

app.UseAuthorization();
app.MapControllers();
app.Run();

RecurringJob.AddOrUpdate("周期性任务", () =>
        Console.WriteLine($"周期性任务：{DateTime.Now.ToLongTimeString()}"), Cron.Minutely);
