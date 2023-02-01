using Quartz;

namespace _004
{
    public class CustomJob : IJob
    {
        private readonly ILogger<CustomJob> _logger;
        public CustomJob(ILogger<CustomJob> logger)
        {
            _logger = logger;
        }
        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Job {dateTime}", DateTime.UtcNow);
            return Task.CompletedTask;
        }
    }

}
