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
            ThreadStart r = SayHello;
            var t = new Thread(SayHello);

            t.Start();  //call SayHello on a new Thread
            r();        //call SayHello on the current Thread

            
        }

        public static void SayHello()
        {
            Console.WriteLine($"Hello World from thread {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
