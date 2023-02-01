using Microsoft.Extensions.FileProviders;

namespace _007
{
    public class RedisFileInfo : IFileInfo
    {
        public RedisFileInfo(string name, string content)
        {
            Name = name;
            LastModified = DateTimeOffset.Now;
            _fileContent = Convert.FromBase64String(content);
        }

        public RedisFileInfo(string name, bool isDirectory)
        {
            Name = name;
            LastModified = DateTimeOffset.Now;
            IsDirectory = isDirectory;
        }
        public Stream CreateReadStream()
        {
            var stream = new MemoryStream(_fileContent);
            stream.Position = 0;
            return stream;
        }

        public bool Exists => true;

        public long Length => _fileContent.Length;

        public string Name { get; set; }
        public string PhysicalPath { get; }
        public DateTimeOffset LastModified { get; }
        public bool IsDirectory { get; }

        private readonly byte[] _fileContent;
    }

}
