using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using System.Diagnostics;

namespace OOP15
{
    public class Program
    {
        public static class First
        {

            public static void CreateDomain()
            {
                AppDomain domain = AppDomain.CurrentDomain;
                Console.WriteLine("Name: {0} ", domain.FriendlyName);
                Console.WriteLine("Configuration details: ");
                Console.WriteLine("\tAppName: {0}\n\tFramework v.: {1}\n\tConfig. File: {2}", domain.SetupInformation.ApplicationName, domain.SetupInformation.TargetFrameworkName, domain.SetupInformation.ConfigurationFile);
                Console.WriteLine("Assembly: ");
                foreach (var i in domain.GetAssemblies())
                {
                    Console.WriteLine("\t{0}", i.ToString());
                }
                AppDomain newDomain = AppDomain.CreateDomain("New");
                Assembly assembly = Assembly.LoadFrom("OOP15.exe");
                newDomain.Load(assembly.FullName);
                AppDomain.Unload(newDomain);
            }
            public static StreamWriter writer = new StreamWriter("OOP15.txt");
            public static void ProcInfo()
            {
                Process[] allProcesses = Process.GetProcesses();
                foreach (Process i in allProcesses)
                {
                    if (i.ProcessName != "Idle")
                    {
                        Console.WriteLine("Id: {0}\tName: {1}\tPriority: {2}\t\nStart time: {3}\tWork time: {4}", i.Id, i.ProcessName, i.BasePriority, i.StartTime, i.TotalProcessorTime);
                    }
                }
            }
            public static void WritePrimeNumbers(object endNum)
            {
                bool IsPrime(int x)
                {
                    for (int i = 2; i <= x / i; i++)
                        if ((x % i) == 0) return false;
                    return true;
                }

                for (int i = 1; i < (int)endNum; i++)
                {
                    if (IsPrime(i))
                    {
                        Console.WriteLine(i);
                        Thread.Sleep(1000);
                    }
                }
            }

            public static bool IsOdd(object o)
            {
                int x = (int)o;
                return (x % 2 == 1) ? true : false;

            }
            public static void WriteOddNumbers(object o)
            {
                int endNum = (int)o;
                for (int i = 1; i <= endNum; i++)
                {
                    Thread.Sleep(200);
                    if (IsOdd(i))
                    {
                        Console.WriteLine(i);
                        writer.WriteLine(i);

                    }
                }

            }
            public static void WriteEvenNumbers(object o)
            {
                int endNum = (int)o;
                for (int i = 1; i <= endNum; i++)
                {
                    Thread.Sleep(1000);
                    if (!IsOdd(i))
                    {
                        Console.WriteLine(i);
                        writer.WriteLine(i);
                    }
                }
            }
            public static void PrintTime(object state)
            {
                Console.Clear();
                Console.WriteLine("TIME:  " +
                    DateTime.Now.ToLongTimeString());
            }
        }
        static void Main(string[] args)
        {

            First.ProcInfo();
            First.CreateDomain();
            Console.WriteLine("Enter your number: ");
            int endNum = int.Parse(Console.ReadLine());
            Thread thread = new Thread(new ParameterizedThreadStart(First.WritePrimeNumbers))
            {

                Name = "Simple Numbers",
                Priority = ThreadPriority.AboveNormal

            };
            Console.WriteLine(thread.ThreadState);
            Thread.Sleep(1000);
            thread.Start(endNum);
            Console.WriteLine(thread.ThreadState);
            Thread.Sleep(1000);
            thread.Suspend();
            Console.WriteLine(thread.ThreadState);
            Thread.Sleep(1000);
            Console.WriteLine(thread.ThreadState);
            Thread.Sleep(3000);
            thread.Resume();
            Console.WriteLine("Name: {0}   Priority: {1}   Number: {2}   Status: {3}", thread.Name, thread.Priority, thread.ManagedThreadId, thread.ThreadState);
            Thread.Sleep(5000);
            Console.WriteLine(thread.ThreadState);
            thread.Abort();
            Console.WriteLine(thread.ThreadState);
            Console.WriteLine("Enter your number: ");
            endNum = int.Parse(Console.ReadLine());

            Thread thread1 = new Thread(new ParameterizedThreadStart(First.WriteOddNumbers));
            Thread thread2 = new Thread(new ParameterizedThreadStart(First.WriteEvenNumbers))
            {
                Priority = ThreadPriority.Highest
            };
            thread2.Start(endNum);
            thread1.Start(endNum);
            if (!thread1.IsAlive)
            {
                thread1.Abort();
            }
            if (!thread2.IsAlive)
            {
                thread2.Abort();
            }
            Console.ReadLine();
            First.writer.Close();

            TimerCallback timer = new TimerCallback(First.PrintTime);

            Timer timer2 = new Timer(timer, null, 0, 1000);
            Console.ReadLine();
        }
    }
}