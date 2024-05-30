using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDem01
{
     class Program
    {
        static void Main()
        {
            var t1 = new Task(SayHello);
            var t2= new Task(SayHello);
            t1.Start();
            t2.Start();

            //t1.Wait();
            //t2.Wait();

            Task.WaitAll(t1, t2);
            


            Console.WriteLine("Program Ends");

        }
        public static void SayHello()
        {
            Thread.Sleep(2000);
            Console.WriteLine($"Hello World from thread {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
