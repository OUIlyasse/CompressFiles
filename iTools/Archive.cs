using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTools
{
    public class Archive
    {
        public void Compress(FileInfo file)
        {
            using (FileStream origine = file.OpenRead())
            {
                if ((File.GetAttributes(file.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden & file.Extension != ".gz")
                {
                    using (FileStream fileCompressed = File.Create(file.FullName + ".gz"))
                    {
                        using (GZipStream compressStream = new GZipStream(fileCompressed, CompressionMode.Compress))
                        {
                            origine.CopyTo(compressStream);
                        }
                    }
                }
            }
        }
        public void Decompress(FileInfo file)
        {
            using (FileStream origine = file.OpenRead())
            {
                string currentFileName = file.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - file.Extension.Length);
                using (FileStream DecompressFile = File.Create(newFileName))
                {
                    using (GZipStream DecompresStream = new GZipStream(origine, CompressionMode.Decompress))
                    {
                        if (file.Extension == ".gz")
                        {
                            DecompresStream.CopyTo(DecompressFile);
                        }
                    }
                }
            }
        }
    }
}