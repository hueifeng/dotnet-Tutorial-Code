using Microsoft.Extensions.Configuration;

namespace MiniConfig.Client
{
    public class _1ConfigurationSource : IConfigurationSource
    {
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new _1ConfigurationProvider();
        }
    }
}




