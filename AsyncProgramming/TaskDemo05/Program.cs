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
            Task<int> permutationTask = Permutation(n, r);


            Console.WriteLine("Please wait...");
            while (!permutationTask.IsCompleted)
            {
                Console.Write("P ");
                Thread.Sleep(100);
            }


            Console.WriteLine($"\n{n}P{r} = {permutationTask.Result}");


            var combination= Combination(n,r);
            while(!combination.IsCompleted)
            {
                Console.Write("C ");
                Thread.Sleep(100);
            }

            Console.WriteLine($"\n{n}C{r} = {combination.Result}");




        }

        private static Task<int> Combination(int n, int r)
        {
            return Task
                        .WhenAll(
                                Task.Factory.StartNew(() => n.Factorial()),
                                Task.Factory.StartNew(() => (n - r).Factorial()),
                                Task.Factory.StartNew(() => r.Factorial())
                        )
                        .ContinueWith(t => t.Result[0] / t.Result[1] / t.Result[2]);
        }




        private static Task<int> Permutation(int n, int r)
        {
            var fn = Task.Factory.StartNew(() => n.Factorial()); //returns a Task that will return 'int' on finish

            var fn_r = Task.Factory.StartNew(() => (n - r).Factorial());


            var waitingForResultTask = Task.WhenAll(fn, fn_r);


            var permutationTask = waitingForResultTask
                                     .ContinueWith(t => //t is same as waitingForResultTask  --> this is a future tense
                                    {
                                        //t.Result is an array of all results collected from all other tasks passed in WhenAll
                                        var fn = t.Result[0];
                                        var fn_r = t.Result[1];
                                        var result = fn / fn_r;
                                        return result;
                                    });


            return permutationTask;
        }
    }
}
