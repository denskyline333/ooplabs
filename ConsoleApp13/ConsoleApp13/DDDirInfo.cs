using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ConsoleApp13
{
    static class DDDirInfo
    {
        public static void FilesCount(string path)
        {
            Console.WriteLine("Количество файлов в каталоге {0}: {1}", path, Directory.GetFiles(path).Length);
        }

        public static void DirCreationTime(string path)
        {
            Console.WriteLine("Время создания каталога {0}: {1}", path, Directory.GetCreationTime(path));
        }

        public static void SubDirectoriesCount(string path)
        {
            Console.WriteLine("Количество подкаталогов в каталоге {0}: {1}", path, Directory.GetDirectories(path).Length);
        }

        public static void ParentDirList(string path)
        {
            Console.WriteLine("Родительский каталог каталога {0}: {1}", path, Directory.GetParent(path));
        }
    }
}
