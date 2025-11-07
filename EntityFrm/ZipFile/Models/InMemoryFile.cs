using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace ZipFile.Models
{
    public class O
    {

        public static InMemoryFile LoadFromFile(string path)
        {
            using var fs = File.OpenRead(path);
            using var memFile = new MemoryStream();
            fs.CopyTo(memFile);

            memFile.Seek(0, SeekOrigin.Begin);

Console.WriteLine(Path.GetFileName(path));
            return new InMemoryFile() { Content = memFile.ToArray(), FileName = "Pasta1/Sub2/"+ Path.GetFileName(path) };
        }


        public static byte[] GetZipArchive(IEnumerable<InMemoryFile> files)
        {
            byte[] archiveFile;
            using (var archiveStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(archiveStream, ZipArchiveMode.Create, true))
                {
                    foreach (var file in files)
                    { 

                        var zipArchiveEntry = archive.CreateEntry(file.FileName, CompressionLevel.Fastest);
                        using (var zipStream = zipArchiveEntry.Open())
                            zipStream.Write(file.Content, 0, file.Content.Length);
                    }
                }

                archiveFile = archiveStream.ToArray();
            }

            return archiveFile;
        }
    }
    public class InMemoryFile {
        public string FolderName { get; set; }
        public string FileName { get; set; }
        public byte[] Content { get; set; }
    }
}