using System;
using System.Threading;
namespace Concurrent
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main Thread : {Thread.CurrentThread.ManagedThreadId}");
            var t = new Thread(WirteY);
            t.Start();
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("X");
            }
        }

        static void WirteY()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("Y");
            }
        }
    }
}
