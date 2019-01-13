using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace ConsoleApp13
{
    static class DDFileManager
    {
        public static void InspectDrive(string drive)
        {
            DirectoryInfo dir = new DirectoryInfo(drive);
            FileInfo[] file = dir.GetFiles();
            Directory.CreateDirectory(@"DDInspect");
            using
                (StreamWriter streamWriter = new StreamWriter(@"DDInspect\dddirinfo.txt"))
            {
                foreach (DirectoryInfo d in dir.GetDirectories())
                    streamWriter.WriteLine(d.Name);
                foreach (FileInfo f in file)
                    streamWriter.WriteLine(f.Name);
            }
     
            File.Copy(@"DDInspect\dddirinfo.txt", @"DDInspect\dddirinfo after copy.txt");
            File.Delete(@"DDInspect\dddirinfo.txt");
        }

        public static void CopyFiles(string path, string exit)
        {
            string dirpath = @"DDFiles";
            Directory.CreateDirectory(dirpath);
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                if (file.Extension == exit)
                    file.CopyTo($@"{dirpath}\{file.Name}");
            }
            Directory.Move(@"DDFiles", @"DDInspect\DDFiles");
        }

        public static void Zip()
        {
            string dirpath = @"DDInspect\DDFiles";
            string zippath = @"DDInspect\DDFiles.zip";
            string zipback = @"Zipback";
            ZipFile.CreateFromDirectory(dirpath, zippath);
            ZipFile.ExtractToDirectory(zippath, zipback);
        }
    }
}
