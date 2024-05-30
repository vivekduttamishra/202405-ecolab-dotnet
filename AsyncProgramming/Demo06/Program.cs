using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo06
{
    public  class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hit Enter to Start the Race...");
            Console.ReadLine();
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            var turtle = new Counter("Turtle", ThreadPriority.BelowNormal);
            var hare = new Counter("Hare", ThreadPriority.AboveNormal);

            Console.WriteLine("Race Started...");
            Thread.Sleep(5000);
            Console.WriteLine("Stopping...");

            hare.Stop();
            turtle.Stop();

            hare.Wait();
            turtle.Wait();

            Console.WriteLine("Race Stopped...");
            Console.WriteLine($"Hare counted {hare.Count}");
            Console.WriteLine($"Turtle Counted {turtle.Count}");
            
        }
    }
}
