using Quartz;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();
    var jobKey = new JobKey("CustomJob");

    q.AddJob<CustomJob>(o => o.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey)
        .WithIdentity(jobKey + "trigger")
        //从第0秒开始，每5秒执行一次
        .WithCronSchedule("0/5 * * * * ?"));
});

builder.Services.AddQuartzServer(q =>
{
    q.WaitForJobsToComplete = true;
});

var app = builder.Build();

app.MapGet("/", () =>
{
    return "Hello World!";
});

app.Run();
