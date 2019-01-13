﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Collections.Concurrent;
using System.Net;

namespace OOP16 {
    class Program {
           static CancellationTokenSource tokenSource = new CancellationTokenSource();
           static void Main(string[] args) 
           {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Task simple = new Task(() => { WritePrime(); });
            simple.Start();
            Console.WriteLine("Identf: {0} Status: {1}", simple.Id, simple.Status);
            simple.Wait();
            Console.WriteLine("Identf: {0} Status: {1}", simple.Id, simple.Status);
            stopwatch.Stop();
            Console.WriteLine("Work time: {0}:{1}", stopwatch.Elapsed.Seconds, stopwatch.Elapsed.Milliseconds);
            stopwatch.Reset();
            DisplayResultAsync();
            
            Task token = new Task(WritePrime, tokenSource.Token);
            token.Start();
            string s = Console.ReadLine();
            if (s == "e")
            {
                tokenSource.Cancel();
            }
            token.Wait();


            Task<int> task1 = Task.Run(() => Formula1(7, 2));
            Task<int> task2 = Task.Run(() => Formula2(4));
            Task<int> task3 = Task.Run(() => Formula3(-3));
            Task<int> result = Task.Run(() => ResultFormula(task1.Result, task2.Result, task3.Result));

            Task continuation = Task.WhenAll(result).ContinueWith(t => Console.WriteLine("Continue"));
           // Task continuation = Task.Run(() => Console.WriteLine("Continue"));

            var awaiter = result.GetAwaiter();
            awaiter.OnCompleted(() => Console.WriteLine("Awaiter result: {0}", awaiter.GetResult()));

            Console.WriteLine("Task1: {0}", task1.Result);
            Console.WriteLine("Task2: {0}", task2.Result);
            Console.WriteLine("Task3: {0}", task3.Result);
            Console.WriteLine("Result: {0}", result.Result);


            double[] array = new double[1000000];
            stopwatch.Start();
            Parallel.For(0, array.Length, i =>
            {
                double a = Math.Log(i);
                array[i] = Math.Pow(a, Factorial(100));
            });
            stopwatch.Stop();
            Console.WriteLine("Время выполнения Parallel.For: {0}:{1}", stopwatch.Elapsed.Seconds, stopwatch.Elapsed.Milliseconds);

            stopwatch.Reset();

            stopwatch.Start();
            for (int i = 0; i < array.Length; i++)
            {
                double a = Math.Log(i);
                array[i] = Math.Pow(a, Factorial(100));
            }
            stopwatch.Stop();
            Console.WriteLine("Время выполнения for: {0}:{1}", stopwatch.Elapsed.Seconds, stopwatch.Elapsed.Milliseconds);
            stopwatch.Reset();


            stopwatch.Start();
            Parallel.Invoke(() =>
            {
                for (int i = 0; i < array.Length; i++)
                {
                    double a = Math.Log(i);
                    array[i] = Math.Pow(a, Factorial(100));
                }
            });
            stopwatch.Stop();
            Console.WriteLine("Время выполнения Parallel.Invoke: {0}:{1}", stopwatch.Elapsed.Seconds, stopwatch.Elapsed.Milliseconds);
            stopwatch.Reset();

            stopwatch.Start();
            for (int i = 0; i < array.Length; i++)
            {
                double a = Math.Log(i);
                array[i] = Math.Pow(a, Factorial(100));
            }
            stopwatch.Stop();
            Console.WriteLine("Время выполнения for: {0}:{1}", stopwatch.Elapsed.Seconds, stopwatch.Elapsed.Milliseconds);
            stopwatch.Reset();
            Console.WriteLine();
     


            BlockingCollection<int> blockcoll = new BlockingCollection<int>();
            for (int producer = 0; producer < 10; producer++)
            {
                Task.Factory.StartNew(() =>
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(200);
                        blockcoll.Add(i * producer);
                        Console.WriteLine("Produces add " + i);
                    }
                });
            }
            Task consumer = Task.Factory.StartNew(() =>
            {
                foreach (var item in blockcoll.GetConsumingEnumerable())
                {
                    Console.WriteLine("Reading "+item);
                }
            });
            consumer.Wait();

            DisplayResultAsync();
        }

        public static void WritePrime() {
            int n = 100;
            bool[] A = new bool[n];
            for (int i = 2; i < n; i++) {
                A[i] = true;
            }

            for (int i = 2; i < Math.Sqrt(n) + 1; ++i) {
                if (A[i]) {
                    for (int j = i * i; j < n; j += i) {
                        A[j] = false;
                    }
                }
            }
            Console.WriteLine();
            for (int i = 2; i < n; i++) {
                if (tokenSource.IsCancellationRequested) {
                    Console.WriteLine("Операция прервана токеном");
                    return;
                }
                if (A[i])
                    Console.WriteLine("{0} ", i);
            }
        }


        public static int Factorial(int x) {
            int result = 1;
            for (int i = 1; i <= x; i++) {
                result *= i;
            }
            return result;
        }

        public static int Formula1(int x, int y) {
            return (int)(x * (8 - Math.Pow(y, 3.5) / 3 + Math.Cos(-1)));
        }

        public static int Formula2(int x) {
            return (int)(9 * (x - 5) + 4 / 3 + Math.Sin(5));
        }

        public static int Formula3(int x) {
            return (int)(-17 / 12 * (-x + 4) / x * 33);
        }

        public static int ResultFormula(int x, int y, int z) {
            return (x + y + z);
        }


        static Task<int> FactorialAsync(int x) {
            int result = 1;
            return Task.Run(() =>
            {
                for (int i = 1; i <= x; i++) {
                    result *= i;
                }
                return result;
            });
        }
        static async void DisplayResultAsync() {
            int num = 12;
            int result = await FactorialAsync(num);
            Thread.Sleep(3000);
            Console.WriteLine("The Factorual of number {0} is {1}", num, result);
        }
    }
}