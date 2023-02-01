using Microsoft.Extensions.Configuration;
using MiniConfig.Client.Parsers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MiniConfig.Client
{
    public class SimpleConfigurationProvider : ConfigurationProvider, IDisposable
    {
        private readonly SimpleConfigurationSource _source;
        private readonly Lazy<HttpClient> _httpClient;
        private bool _isDisposed;
        private CancellationTokenSource? _cts;
        private HttpClient HttpClient => _httpClient.Value;
        public SimpleConfigurationProvider(SimpleConfigurationSource source)
        {
            _source = source ?? throw new ArgumentException(nameof(source));
            _httpClient = new Lazy<HttpClient>(CreateHttpClient);
        }
        private HttpClient CreateHttpClient()
        {
            var handler = new HttpClientHandler();
            var client = new HttpClient(handler, true)
            {
                BaseAddress = new Uri(_source.ConfigurationServiceUri),
                Timeout = _source.RequestTimeout
            };
            return client;
        }
        private async Task RequestConfigurationAsync(CancellationToken cancellationToken)
        {
            var encodedConfigurationName = WebUtility.HtmlEncode(_source.ConfigurationName);
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    using (var response = await HttpClient.GetAsync(encodedConfigurationName, cancellationToken).ConfigureAwait(false))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            using (var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false))
                            {
                                stream.Position = 0;
                                var data = new JsonConfigurationFileParser().Parse(stream);
                                if (response.StatusCode == HttpStatusCode.OK)
                                {
                                    Notify(data);
                                }
                            }
                        }

                    }
                }
                finally
                {
                    await Task.Delay(50, cancellationToken).ConfigureAwait(false);
                }
            }
        }
        private void Notify(IDictionary<string, string> data)
        {
            Data = data;
            OnReload();
        }

        public override void Load()
        {
            LoadAsync();
        }

        private async Task LoadAsync()
        {
            CancellationTokenSource cancellationToken = Interlocked.Exchange(ref _cts, new CancellationTokenSource());
            if (cancellationToken != null)
            {
                return;
            }
            await RequestConfigurationAsync(_cts.Token);
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }
            if (_httpClient?.IsValueCreated == true)
            {
                _httpClient.Value.Dispose();
            }
            _isDisposed = true;
        }
    }
}





