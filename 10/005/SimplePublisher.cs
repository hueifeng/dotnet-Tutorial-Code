using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text;

namespace _005
{
    public class SimplePublisher : IHealthCheckPublisher
    {
        public Task PublishAsync(HealthReport report, CancellationToken cancellationToken)
        {
            if (report.Status == HealthStatus.Healthy)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{DateTime.UtcNow} Prob status: {report.Status}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{DateTime.UtcNow} Prob status: {report.Status}");
            }
            var sb = new StringBuilder();

            foreach (var name in report.Entries.Keys)
            {
                sb.AppendLine($" {name}: {report.Entries[name].Status}");
            }
            cancellationToken.ThrowIfCancellationRequested();
            Console.WriteLine(sb);
            Console.ResetColor();
            return Task.CompletedTask;
        }
    }

}
