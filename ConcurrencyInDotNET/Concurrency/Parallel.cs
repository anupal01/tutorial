using System;
namespace ConcurrencyInDotNET
{
    public class ParallelClass
    {
        private static int count = 0;
        public ParallelClass()
        {

        }

        public void DoWork(int number)
        {
            for (int i = 0; i < number; i++)
            {
                Random r = new Random();
                System.Threading.Thread.Sleep(r.Next(2) * 1000);
                //lock(locker)
                //{
                //    count++;
                //}
                count++;
                Console.WriteLine($"ThreadId {System.Threading.Thread.CurrentThread.ManagedThreadId} : { count  }");
            }
        }
    }
}
