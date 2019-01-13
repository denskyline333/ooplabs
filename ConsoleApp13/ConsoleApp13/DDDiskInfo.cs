using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp13
{
    static class DDDiskInfo
    {
        public static void Capacity(string drive)
        {
            foreach (DriveInfo d in DriveInfo.GetDrives())
            {
                if (d.Name == drive && d.IsReady)
                    Console.WriteLine("Объем диска {0} = {1}", drive, d.AvailableFreeSpace);                
            }
        }

        public static void FileSystemInfo(string drive)
        {
            foreach (DriveInfo d in DriveInfo.GetDrives())
            {
                if (d.Name == drive && d.IsReady)
                    Console.WriteLine("Тип файловой системы и формат диска {0} = {1}, {2}", drive, d.DriveType, d.DriveFormat);
            }

        }

        public static void DrivesInfo()
        {
            foreach (DriveInfo d in DriveInfo.GetDrives())
            {
                if (d.IsReady)
                {
                    Console.WriteLine("Имя: " + d.Name);
                    Console.WriteLine("Объем: " + d.TotalSize);
                    Console.WriteLine("Доступный объем: " + d.AvailableFreeSpace);
                    Console.WriteLine("Метка тома: " + d.VolumeLabel);
                }
                Console.WriteLine();

            }
            Console.WriteLine();
        }
    }
}
