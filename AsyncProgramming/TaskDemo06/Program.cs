
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo07
{
    public class Program
    {
        public static void Main()
        {
            var tasks = new List<Task>();

            for(int i= 0; i < 10; i++)
            {
                var t = Task.Factory.StartNew(FaultyTask);
                tasks.Add(t);               
                
            }
                
            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException ex)
            {
                foreach(var innerException in ex.InnerExceptions)
                    Console.WriteLine(innerException.Message);
            }


            Console.WriteLine("Program Ends...");

        }
        static Random rnd = new Random();


        static void FaultyTask()
        {
            var id=Thread.CurrentThread.ManagedThreadId; 
            Console.WriteLine($"Task Started on Thread {id}");
            if (rnd.Next(100) > 50)
                throw new InvalidOperationException($"Something went wrong with Thread {id} ");

            Console.WriteLine($"Task completed on Thread {id}"); ;
        }

       
    }
}
