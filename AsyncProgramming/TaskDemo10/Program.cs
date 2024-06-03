
using ConceptArchitect.Collections;
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
            //TestInvoke();

            //ParellelForTest();

            int max = 200000;

            Console.WriteLine("Finding Primes using sync algorithm...");
            var r1 = PerformanceMeasure.InvokeTimed(() => FindPrimes(2, max));
            Console.WriteLine($"Synced Version Total Primes: {r1.ReturnValue.Count}. Time Taked:{r1.TimeTaken.TotalMilliseconds} ms");

            Console.WriteLine("Finding Primes using async algorithm...");
            var r2= PerformanceMeasure.InvokeTimed(() => FindPrimesAsync(2, max).Result);
            Console.WriteLine($"Async synced Version Total Primes: {r2.ReturnValue.Count}. Time Taked:{r2.TimeTaken.TotalMilliseconds} ms");

        }

        static bool IsPrime(int n)
        {
            return false; //fake
        }
        static List<int> FindPrimes(int min, int max)
        {
            var result = new List<int>();

            for(int i=min;i<= max;i++) 
            {
                if (IsPrime(i))
                {
                    
                     result.Add(i);
                    
                        
                }
            }

            return result;
        }

        bool isPrime(int n)
        {
            return false; //fake
        }

        async static Task<List<int>> FindPrimesAsync(int min,int max)
        {
            var result=new List<int>();
            var pfr= Parallel.For(min, max, i =>
             {
                 if(IsPrime(i))
                 {
                     lock(result)
                        result.Add(i);
                 }
             });

            await Task.Factory.StartNew(() =>
            {
                while (!pfr.IsCompleted)
                    Thread.Sleep(10);
            });



            return result;
        }


        private static void ParellelForTest()
        {
            Parallel.For(0, 10, i =>  //for(int i=0;i<10;i++){
            {
                Console.WriteLine($"Task {i} Running on Thread {Thread.CurrentThread.ManagedThreadId}");
            });
        }

        private static void TestInvoke()
        {
            var task = () => Console.WriteLine($"Job Running on Thread {Thread.CurrentThread.ManagedThreadId}");
            Parallel.Invoke(
                    task, task, task
                );

            Console.ReadLine();
        }


        public  static async  Task<int> Permutation(int n,int r)
        {
                var fn = await Factorial(n);
                var fn_r = await Factorial(n - r);

                
                return fn / fn_r;

        }


        public static async  Task<int> Factorial(int n)
        {   
            int result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
                await Task.Delay(1000);
            }
            return result;
        }

       
    }
}
