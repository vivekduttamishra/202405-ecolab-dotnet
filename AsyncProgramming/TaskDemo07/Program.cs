
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
            int n = 8, r = 3;


            var task= PrintPermutationResult(n, r)
                            .ContinueWith((t)=>Console.WriteLine("Program Ends"));

            Console.WriteLine("Please wait...");


            task.Wait();
            

        }

        static async Task PrintPermutationResult(int n, int r)
        {
            var p=await Permutation(n, r);
            Console.WriteLine($"{n}P{r} = {p}");

        }

        static  Task<int> Permutation(int n,int r)
        {
            return Task.Factory.StartNew(() =>
            {
                var fn = Factorial(n);
                var fn_r = Factorial(n - r);

                fn.Wait();
                fn_r.Wait();

                return fn.Result / fn_r.Result;

            });
        }


        static Task<int> Factorial(int n)
        {
            return Task.Factory.StartNew(() =>
            {
                int result = 1;
                for (int i = 1; i <= n; i++)
                {
                    result *= i;
                    Thread.Sleep(1000);
                }
                return result;
            });
        }

       
    }
}
