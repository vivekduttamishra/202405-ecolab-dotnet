
using Demo05;
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
            int n2 = 5, r2 = 3;

            //PerformanceResult<int> x = TestPermutationSync(n, r, n2, r2);

            var x = TestPermutationAsync1(n, r, n2, r2);
            Console.WriteLine($"Total Time Taken:{x.TimeTaken.TotalMilliseconds} ms");



            Console.WriteLine("Please wait...");





        }

        private static PerformanceResult<int> TestPermutationAsync1(int n, int r, int n2, int r2)
        {
            return PerformanceMeasure.MeasurePerformance(() =>
            {

                Console.WriteLine($"calculating Permutation({n},{r})");
                var result1 = PermutationAsync1(n, r);
                Console.WriteLine($"calculating Permutation({n2},{r2})");
                var result2 = PermutationAsync1(n2, r2);


                Task.WaitAll(result1, result2);
                Console.WriteLine($"result1:{result1.Result}");
                Console.WriteLine($"result2:{result2.Result}");
                return 0;
            });
        }

        private static PerformanceResult<int> TestPermutationSync(int n, int r, int n2, int r2)
        {
            return PerformanceMeasure.MeasurePerformance(() =>
            {

                Console.WriteLine($"calculating Permutation({n},{r})");
                var result1 = PermutationSync(n, r);
                Console.WriteLine($"calculating Permutation({n2},{r2})");
                var result2 = PermutationSync(n2, r2);
                Console.WriteLine($"result1:{result1}");
                Console.WriteLine($"result2:{result2}");
                return 0;
            });
        }


        private static PerformanceResult<int> TestPermutationAsync(int n, int r, int n2, int r2)
        {
            return PerformanceMeasure.MeasurePerformance( () =>
            {
                PermutationAsyncPrint(n, r, n2, r2).Wait();
                return 0;
            });
        }

        public static async Task PermutationAsyncPrint(int n, int r,int n2,int r2)
        {
            Console.WriteLine($"calculating Permutation({n},{r})");
            var result1 = await PermutationAsync(n, r);
            Console.WriteLine($"calculating Permutation({n2},{r2})");
            var result2 = await PermutationAsync(n2, r2);
            Console.WriteLine($"result1:{result1}");
            Console.WriteLine($"result2:{result2}");
            
        }


        static async Task<int> PermutationAsync(int n,int r)
        {
            int fn = await Factorial(n);
            int fn_r = await Factorial(n - r);

            return fn/fn_r; //int
        }


        static Task<int> PermutationAsync2(int n, int r)
        {
            
                var fn = Factorial(n);
                var fn_r = Factorial(n - r);

        
                return Task
                            .WhenAll(fn, fn_r) 
                            .ContinueWith(whenAllTask =>
                            {
                                return whenAllTask.Result[0]/whenAllTask.Result[1];
                            });
        }


        static  Task<int> PermutationAsync1(int n,int r)
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

        static int PermutationSync(int n, int r)
        {
            var fn = Factorial(n);
            var fn_r = Factorial(n - r);

            //fn.Wait();
            //fn_r.Wait();

            Task.WaitAll(fn, fn_r); //blocking

            return fn.Result / fn_r.Result;

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
