using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace _002
{
    public class MyBackgroundService : BackgroundService
    {
        private readonly ILogger<MyBackgroundService> _logger;
        public MyBackgroundService(ILogger<MyBackgroundService> logger)
        {
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Starting IHostedService registered in Startup");
            while (true)
            {
                DoWork();
                await Task.Delay(5000);
            }
        }
        private void DoWork()
        {
            _logger.LogInformation($"Hello World! - {DateTime.Now}");
        }
    }

}
