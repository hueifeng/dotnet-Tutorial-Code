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
        //�ӵ�0�뿪ʼ��ÿ5��ִ��һ��
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
