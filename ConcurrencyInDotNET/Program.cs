using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrencyInDotNET
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"ThreadId {System.Threading.Thread.CurrentThread.ManagedThreadId} !");
            var concurrency = new ConcurrentClass();
            var t1 = Task.Run(() => concurrency.DoWork(80));
            var t2 = Task.Run(() => concurrency.DoWork(50));
            var t3 = Task.Run(() => concurrency.DoWork(20));
            var t4 = Task.Run(() => concurrency.DoWork(30));
            Task.WaitAll(t1, t2, t3, t4);
            Console.WriteLine($"Concurrency {System.Threading.Thread.CurrentThread.ManagedThreadId} done!");

            //var parallel = new ParallelClass();
            //var thread1 = new Thread(() => parallel.DoWork(10));
            //var thread2 = new Thread(() => parallel.DoWork(50));
            //var thread3 = new Thread(() => parallel.DoWork(20));
            //var thread4 = new Thread(() => parallel.DoWork(30));
            //thread1.Start();
            //thread2.Start();
            //thread3.Start();
            //thread4.Start();
            //thread4.Join();
            //thread3.Join();
            //thread2.Join();
            //thread1.Join();
            Console.ReadLine();
        }
    }
}
