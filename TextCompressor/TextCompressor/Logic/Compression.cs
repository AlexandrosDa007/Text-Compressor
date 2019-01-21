using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCompressor.Logic
{
    /// <summary>
    /// Provides static functions to compress and decompress byte arrays
    /// </summary>
    public class Compression
    {

        /// <summary>
        /// Returns a compressed byte array given a decompressed byte array.
        /// </summary>
        /// <param name="decompressedFile"></param>
        /// <returns></returns>
        public static byte[] CompressFile(byte[] decompressedFile)
        {

            try
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    using (GZipStream gzip = new GZipStream(memory,
                        CompressionMode.Compress, true))
                    {
                        gzip.Write(decompressedFile, 0, decompressedFile.Length);
                    }
                    return memory.ToArray();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Returns a decompressed byte array given a compressed byte array.
        /// </summary>
        /// <param name="compressedFile"></param>
        /// <returns></returns>
        public static byte[] DecompressFile(byte[] compressedFile)
        {
            // Create a GZIP stream with decompression mode.
            // ... Then create a buffer and write into while reading from the GZIP stream.
            try
            {
                using (GZipStream stream = new GZipStream(new MemoryStream(compressedFile),
                        CompressionMode.Decompress))
                {
                    const int size = 4096;
                    byte[] buffer = new byte[size];
                    using (MemoryStream memory = new MemoryStream())
                    {
                        int count = 0;
                        do
                        {
                            count = stream.Read(buffer, 0, size);
                            if (count > 0)
                            {
                                memory.Write(buffer, 0, count);
                            }
                        }
                        while (count > 0);
                        return memory.ToArray();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

    }
}
