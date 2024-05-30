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
        static void Main()
        {
            var c = new CountDown();

            //c.Run(10);

            var t1 = new Thread(() => c.Run(100));
            var t2 = new Thread(_ => c.Run(1500)); //this is background
            var t3 = new Thread(_ => c.Run(200));

            t2.IsBackground = true; //It is non-critical. Must be set before start

            t1.Start();
            t2.Start();
            t3.Start();

            //BusyMain();

            // Thread.Sleep(5000);

            //CheckIsAlive(t1, t2, t3);

            t1.Join(); //wait for t1 to finish
            //t2.Join(); // a foreground thread runs till this background thread finishes
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

