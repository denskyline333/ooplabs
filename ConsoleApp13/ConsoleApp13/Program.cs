using System;
using System.Threading;
using System.IO;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(DDLog.Begin);
            thread.Start();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DiskInfo: ");
            Console.ForegroundColor = ConsoleColor.White;
            DDDiskInfo.Capacity("D:\\");
            DDDiskInfo.Capacity("C:\\");
            DDDiskInfo.FileSystemInfo("D:\\");
            DDDiskInfo.FileSystemInfo("C:\\");
            Console.WriteLine();
            DDDiskInfo.DrivesInfo();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("FileInfo: ");
            Console.ForegroundColor = ConsoleColor.White;
            DDFileInfo.FullPath(@"D:\Notepad++\notepad++.exe");
            DDFileInfo.InfoThree(@"D:\Notepad++\notepad++.exe");
            DDFileInfo.CreationTime(@"D:\Notepad++\notepad++.exe");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("DirectoriesInfo: ");
            Console.ForegroundColor = ConsoleColor.White;
            DDDirInfo.FilesCount(@"D:\Фильмы");
            DDDirInfo.DirCreationTime(@"D:\Фильмы");
            DDDirInfo.SubDirectoriesCount(@"D:\Фильмы");
            DDDirInfo.ParentDirList(@"D:\Фильмы");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("FileManager: ");
            Console.ForegroundColor = ConsoleColor.White;
            DDFileManager.InspectDrive(@"D:\");
            DDFileManager.CopyFiles(@"D:\Notepad++", ".exe");
            DDFileManager.Zip();
            thread.Abort();
        }
    }
}
