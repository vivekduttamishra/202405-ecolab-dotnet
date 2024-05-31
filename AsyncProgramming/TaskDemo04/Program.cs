using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDemo04
{
    internal class Program
    {
        static void Main()
        {
            int n = 8, r = 3;

            Task<int> fn = Task.Factory.StartNew(() => n.Factorial()); //returns a Task that will return 'int' on finish

            //fn.Wait(); //wait for it to finish

            //while(!fn.IsCompleted)
            //{
            //    Console.Write(".");
            //    Thread.Sleep(200);
            //}

            Console.WriteLine("Please wait...");

            Console.WriteLine(fn.Result); //give the result after auto wait





        }
    }
}
