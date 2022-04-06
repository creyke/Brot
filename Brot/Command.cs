using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Brot
{
    public class Command
    {
        public void Execute(string[] args)
        {
            if (args.Length == 0)
            {
                throw new ArgumentException("No string specified.");
            }

            var s = args[0];

            try
            {
                var bytes = Convert.FromBase64String(s);
                Console.Write(BrotliDecompress(bytes));
            }
            catch (Exception)
            {
                Console.Write(BrotliCompress(s));
            }
        }

        static string BrotliCompress(string input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            using var memoryStream = new MemoryStream();
            using (var brotliStream = new BrotliStream(memoryStream, CompressionMode.Compress, true))
            {
                brotliStream.Write(bytes, 0, bytes.Length);
            }
            memoryStream.Position = 0;
            return Convert.ToBase64String(memoryStream.ToArray());
        }

        static string BrotliDecompress(byte[] input)
        {
            var compressed = new MemoryStream(input);
            using var decompressed = new MemoryStream();
            using var decompressor = new BrotliStream(compressed, CompressionMode.Decompress, true);
            decompressor.CopyTo(decompressed);
            return Encoding.UTF8.GetString(decompressed.ToArray());
        }
    }
}
