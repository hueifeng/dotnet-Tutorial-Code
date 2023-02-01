using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MiniConfig.Client
{
    public static class SimpleConfigurationExtensions
    {
        public static IConfigurationBuilder AddSimpleSource(this IConfigurationBuilder builder, SimpleConfigurationSource simpleConfiguration)
        {
            return builder.Add(simpleConfiguration);
        }
    }
}

