using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApp13
{
    static class DDFileInfo
    {
        public static void FullPath(string path)
        { 
            FileInfo fileInfo = new FileInfo(path);
            Console.WriteLine("Полный путь к файлу {0}: {1}", fileInfo.Name, fileInfo.FullName);
          //  Console.WriteLine();
        }

        public static void InfoThree(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            Console.WriteLine("Имя файла: "+ fileInfo.Name);
            Console.WriteLine("Расширение файла: "+ fileInfo.Extension);
            Console.WriteLine("Размер файла: "+ fileInfo.Length);
          //  Console.WriteLine();

        }

        public static void CreationTime(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            Console.WriteLine("Время создания файла {0}: {1}", fileInfo.Name, fileInfo.CreationTime);
            Console.WriteLine();
        }
    }
}

