using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MiniConfig
{
    public class ConfigWriter
    {
        private readonly IOptionsMonitor<TestConfig> _testConfig;

        public ConfigWriter(IOptionsMonitor<TestConfig> testConfig)
        {
            _testConfig = testConfig;
        }
        public async Task Write(CancellationToken cancellationToken = default)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var config = _testConfig.CurrentValue;
                Console.WriteLine(config.Key1);

                await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken);
            }
        }
    }
}
