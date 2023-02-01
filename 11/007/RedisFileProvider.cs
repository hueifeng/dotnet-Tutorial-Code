using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using StackExchange.Redis;

namespace _007
{
    public class RedisFileProvider : IFileProvider
    {
        private readonly RedisFileOptions _options;
        private readonly ConnectionMultiplexer _redis;

        public RedisFileProvider(IOptions<RedisFileOptions> options)
        {
            _options = options.Value;
            _redis = ConnectionMultiplexer.Connect(
                new ConfigurationOptions
                {
                    EndPoints = { _options.HostAndPort }
                });
        }

        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            var db = _redis.GetDatabase();
            var server = _redis.GetServer(_options.HostAndPort);
            var list = new List<IFileInfo>();
            subpath = NormalizePath(subpath);
            foreach (var key in server.Keys(0, $"{subpath}*"))
            {
                var k = "";
                if (subpath != "")
                {
                    k = key.ToString().Replace(subpath, "").Split(":")[0];
                }
                else
                {
                    k = key.ToString().Split(":")[0];
                }

                if (list.Find(f => f.Name == k) == null)
                {
                    //判断是否存在"."
                    if (k.IndexOf('.', StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        list.Add(new RedisFileInfo(k, db.StringGet(k)));
                    }
                    else
                    {
                        list.Add(new RedisFileInfo(k, true));
                    }
                }
            }

            if (list.Count == 0)
            {
                return NotFoundDirectoryContents.Singleton;
            }

            return new EnumerableDirectoryContents(list);
        }

        private static string NormalizePath(string path) => path.TrimStart('/').Replace('/', ':');

        public IFileInfo? GetFileInfo(string subpath)
        {
            subpath = NormalizePath(subpath);
            var db = _redis.GetDatabase();
            var redisValue = db.StringGet(subpath);
            return !redisValue.HasValue ? new NotFoundFileInfo(subpath) :
                new RedisFileInfo(subpath, redisValue.ToString());
        }

        public IChangeToken Watch(string filter) =>
            throw new NotImplementedException();
    }

}
