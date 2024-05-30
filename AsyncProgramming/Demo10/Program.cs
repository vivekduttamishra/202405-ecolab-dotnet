
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo07
{
    public class Program
    {
        public static void Main()
        {
            var threads = new List<Thread>();

            for(int i= 0; i < 10; i++)
            {
                var t = new Thread(FaultyTask);
                threads.Add(t);
                t.Start();
            }
                
            foreach(var t in threads)
            {
                try
                {
                    t.Join();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
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
