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
        static Dictionary<int,int> threadJobs=new Dictionary<int, int>();
        static void Main()
        {
            
            List<Task> tasks=new List<Task>();

            for(int i = 0; i < 1000; i++)
            {
                var id = i;
                var t = new Task(() => LongJob(id, 10));
                t.Start();
                tasks.Add(t);
                
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("Thread#\tWork Done");
            foreach (var id in threadJobs.Keys)
            {
                Console.WriteLine($"{id}\t{threadJobs[id]}");
            }

        }
        public static void LongJob(int id, int time)
        {
            
            var threadId= Thread.CurrentThread.ManagedThreadId;
            if (threadJobs.ContainsKey(threadId))
                threadJobs[threadId]++;
            else
                threadJobs[threadId] = 1;

            Console.WriteLine($"Task #{id} starts on Thread #{threadId}");
            Thread.Sleep(time);
            Console.WriteLine($"Task#{id} ends on Thread #{threadId}");
        }
    }
}
