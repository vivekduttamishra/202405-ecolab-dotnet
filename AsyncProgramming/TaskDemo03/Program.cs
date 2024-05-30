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
            Task[] tasks = new Task[20];
            for(int i = 0; i < tasks.Length; i++)
            {
                var id = i;
                tasks[i] = Task.Factory.StartNew(() => LongJob(id, 2000));
                
                
            }

            foreach (var task in tasks)
                task.Wait();
            //Task.WaitAll(tasks);  

            
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
