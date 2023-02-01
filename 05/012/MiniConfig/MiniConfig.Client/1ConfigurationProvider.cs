using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MiniConfig.Client
{
    public class _1ConfigurationProvider : ConfigurationProvider
    {
        public override void Load()
        {
            using (var httpClient = new HttpClient {
                BaseAddress = new Uri("https://localhost:44360")
            })
            {
                var response = httpClient.GetStringAsync("/configuration/test.json").ConfigureAwait(false).GetAwaiter().GetResult();
                if (!string.IsNullOrEmpty(response))
                {
                    Data = JsonConvert.DeserializeObject<IDictionary<string, string>>(response);
                }
            }
        }
    }
}

