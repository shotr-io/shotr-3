using System;
using System.IO;

namespace Shotr.Core.Uploader
{
    public class FileShell : IDisposable
    {
        public FileShell(byte[] file)
        {
            Data = file;
        }

        public FileShell(string path)
        {
            Path = path;
        }

        public byte[]? Data { get; set; }

        public string? Path { get; set; }

        public string? Name => System.IO.Path.GetFileName(Path);

        public long? Size => Path is { } ? new FileInfo(Path).Length : Data?.Length;

        public void Dispose()
        {

        }
    }
}
