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

            var fn = Task.Factory.StartNew(() => n.Factorial()); //returns a Task that will return 'int' on finish

            //var fn_r = Task.Factory.StartNew(()=>(n-r).Factorial());

            var fn_r = new Task<int>( ()=>(n-r).Factorial());
            fn_r.Start();

            Console.WriteLine("Please wait while we calculate permutation");

            while(!fn.IsCompleted ||!fn_r.IsCompleted)
            {
                Console.Write(".");
                Thread.Sleep(50);
            }
            
            //Task.WaitAll(fn, fn_r);


            var result = fn.Result / fn_r.Result; //if Result is called when Task has not completed it waits internally

            Console.WriteLine($"\n{n}P{r} = {result}");







        }
    }
}
