using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace _001
{
    public class MyHostedService : IHostedService
    {
        private readonly ILogger<MyHostedService> _logger;
        private const int WAITTIME = 5000;//定义等待时间
        public MyHostedService(ILogger<MyHostedService> logger)
        {
            _logger = logger;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting IHostedService registered in Startup");

            while (true)
            {
                await Task.Delay(WAITTIME);
                DoWork();
            }
        }
        private void DoWork()
        {
            _logger.LogInformation($"Hello World! - {DateTime.Now}");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping IHostedService registered in Startup");
            return Task.CompletedTask;
        }
    }

}


