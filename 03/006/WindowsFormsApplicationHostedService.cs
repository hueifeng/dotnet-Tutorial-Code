using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _006
{
    public class WindowsFormsApplicationHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Thread _thread;

        public WindowsFormsApplicationHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            //创建一个STA线程
            _thread = new Thread(UIThreadStart);
            _thread.SetApartmentState(ApartmentState.STA);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _thread.Start();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Application.Exit();
            return Task.CompletedTask;
        }

        private void UIThreadStart()
        {
            var applicationContext = _serviceProvider.GetRequiredService<ApplicationContext>();
            Application.Run(applicationContext);
        }
    }

}
