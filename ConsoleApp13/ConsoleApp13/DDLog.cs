using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApp13
{
    static class DDLog
    {
        static FileSystemWatcher fileSystemWatcher = new FileSystemWatcher
        {
            Path = @"D:\учеба\3 семестр\учеба\ООП\ConsoleApp13\ConsoleApp13\bin\Debug\netcoreapp2.1\",
            IncludeSubdirectories = true,
            NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName |  NotifyFilters.DirectoryName
        };


        public static void OnChanged(object sender, FileSystemEventArgs e)
        {
            using
                (StreamWriter streamWriter = new StreamWriter("ddlog.txt", true))
            {
                streamWriter.WriteLine(DateTime.Now + " --- " + e.ChangeType + " --- Путь: " + e.FullPath);
            }
        }

        public static void Begin()
        {
            fileSystemWatcher.Changed += new FileSystemEventHandler(OnChanged) ;
            fileSystemWatcher.Created += new FileSystemEventHandler(OnChanged);
            fileSystemWatcher.Deleted += new FileSystemEventHandler(OnChanged);
            fileSystemWatcher.EnableRaisingEvents = true;
        }

        public static void Date(string date)
        {
            fileSystemWatcher.EnableRaisingEvents = false;
            using
                (StreamReader streamReader = new StreamReader("ddlog.txt"))
            {
                while(!streamReader.EndOfStream)
                {
                    if(streamReader.ReadLine().StartsWith(date))
                    {
                        Console.WriteLine(streamReader.ReadLine());
                    }
                }
            }
        }

    }
}
