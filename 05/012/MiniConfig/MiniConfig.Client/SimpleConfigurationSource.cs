using Microsoft.Extensions.Configuration;
using System;

namespace MiniConfig.Client
{
    public class SimpleConfigurationSource : IConfigurationSource
    {
        public string ConfigurationServiceUri { get; set; }
        public TimeSpan RequestTimeout { get; set; } = TimeSpan.FromSeconds(60);
        public string ConfigurationName { get; set; }
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new SimpleConfigurationProvider(this);
        }
    }
}


