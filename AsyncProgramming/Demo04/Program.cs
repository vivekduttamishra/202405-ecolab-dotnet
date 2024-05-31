using Demo03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo02
{
    internal class Program
    {


        public static void CountDown(int max)
        {


            var id = Thread.CurrentThread.ManagedThreadId;

            Console.WriteLine($"Thrad #{id}: starts");
            while (max >= 0)
            {
                Console.WriteLine($"Thrad#{id}: counts {max}");
                max--;
            }
            Console.WriteLine($"Thrad #{id}: stops");
        }
        static void Main()
        {


            var t1 = new Thread(() => CountDown(100));
            var t2 = new Thread(_ => CountDown(150)); //this is background
            var t3 = new Thread(_ => CountDown(200));


            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join(); //current thread should wait for t1 to end.
            t2.Join();
            t3.Join();

            Console.WriteLine("Main Ends");

        }

        private static void CheckIsAlive(Thread t1, Thread t2, Thread t3)
        {
            while (t1.IsAlive || t2.IsAlive || t3.IsAlive)
            {
                Console.Write("+");
                Thread.Sleep(100);
            }
        }

        private static void BusyMain()
        {
            for (int i = 0; i < 4500000; i++)
            {
                //loop for 4500                
            }
        }
    }
}

