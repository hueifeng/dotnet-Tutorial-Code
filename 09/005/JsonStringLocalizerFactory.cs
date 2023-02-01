using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Reflection;

namespace _005
{
    public class JsonStringLocalizerFactory : IStringLocalizerFactory
    {
        private readonly ConcurrentDictionary<string, IStringLocalizer> _localizers;
        private readonly IFileProvider _fileProvider;
        public JsonStringLocalizerFactory(IFileProvider fileProvider)
        {
            _localizers = new ConcurrentDictionary<string, IStringLocalizer>();
            _fileProvider = fileProvider;
        }

        public IStringLocalizer Create(Type resourceSource)
        {
            var path = ParseFilePath(resourceSource);
            return _localizers.GetOrAdd(path, _ =>
            {
                return CreateStringLocalizer(_);
            });
        }

        public IStringLocalizer Create(string baseName, string location)
        {
            var path = ParseFilePath(location, baseName);
            return _localizers.GetOrAdd(path, _ =>
            {
                return CreateStringLocalizer(_);
            });
        }

        private IStringLocalizer CreateStringLocalizer(string path)
        {
            var file = _fileProvider.GetFileInfo(path);
            if (!file.Exists)
            {
                return new JsonStringLocalizer(new Dictionary<string, LocalizationStringEntry>());
            }
            var dictionary = JsonConvert.DeserializeObject
    <Dictionary<string, LocalizationStringEntry>>(File.ReadAllText(path));
            return new JsonStringLocalizer(dictionary);
        }

        private string ParseFilePath(string location, string baseName)
        {
            var path = location + "." + baseName;
            return path.Replace("..", ".")
                .Replace('.', Path.DirectorySeparatorChar) + ".json";
        }

        private string ParseFilePath(Type resourceSource)
        {
            var rootNamespaceAttribute = resourceSource.Assembly
    .GetCustomAttribute<RootNamespaceAttribute>()
              ?.RootNamespace ?? new AssemblyName(resourceSource.Assembly.FullName).Name;
            return TrimPrefix(resourceSource.FullName, rootNamespaceAttribute + ".") + ".json";
        }

        private string TrimPrefix(string name, string prefix)
        {
            if (name.StartsWith(prefix, StringComparison.Ordinal))
            {
                return name.Substring(prefix.Length);
            }
            return name;
        }
    }

}
