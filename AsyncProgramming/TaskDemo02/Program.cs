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
            for(int i = 0; i < 20; i++)
            {
                var id = i;
                var t = new Task(() => LongJob(id, 2000));
                t.Start();
                
            }

            Console.WriteLine("Hit Enter to Exit");
            Console.ReadLine();
            Console.WriteLine("Program Ends...");

        }
        public static void LongJob(int id, int time)
        {
            var threadId= Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine($"Task #{id} starts on Thread #{threadId}");
            Thread.Sleep(time);
            Console.WriteLine($"Task#{id} ends on Thread #{threadId}");
        }
    }
}
