
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo05
{
    internal class Program
    {
        static void Main()
        {
            int n = 8;
            int r = 3;

            var result = PerformanceMeasure.MeasurePerformance(() => PermutationAsync(n, r));

            Console.WriteLine($"{n}P{r}={result.Result}");
            Console.WriteLine($"Total Time taken is {result.TimeTaken.TotalMilliseconds} ms");
            
        }


        static int PermutationAsync2(int n,int r)
        {
            int fn = 0, fn_r = 0;


            var t1 = new Thread(() => fn = n.Factorial());

            var t2= new Thread(()=> fn_r= (n-r).Factorial());

            t1.Start();
            t2.Start();

            while (t1.IsAlive || t2.IsAlive)
            {
                Console.Write(".");
                Thread.Sleep(50);
            }

            //We know they finished. so no need to join
            t1.Join();
            t2.Join();

            return fn / fn_r;

        }


        static int PermutationAsync(int n, int r)
        {

            var fn = new Factorial(n); //run the work in parallel

            var fn_r = new Factorial(n-r); //runs work in parallel


            //now we can access the result, when task is over
            //but we will reach here immediately
            //lets make it wait

            

            //Now the task will take n seconds instread of 2n-r seconds.

            return fn.Result / fn_r.Result;
        }

        static int Permutation(int n, int r)
        {
            
            var fn = n.Factorial();
            //wait for first to complete
            var fn_r = (n-r).Factorial();
            //wait for second to complete
            return fn / fn_r;
        }
    }
}
