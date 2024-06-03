using ConceptArchitect.Collections;
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
            TestWorkers(100, 10000, true);

        }

        public static void TestWorkers(int workerCount, long taskPerWorker, bool useSameBasketForAllWorker)
        {
            //Step1. Create an array or worker and assign thme taskPerWorker and basket
            // If useSAmeBasetForAllWorker, then create a single basket and assign it to all worker
            // else create a new basket for each worker and give them

            
            Basket commonBasket = new Basket();

            Worker[] workers = new Worker[workerCount];
            for (int i = 0; i < workerCount; i++)
            {
                var basket = useSameBasketForAllWorker ? commonBasket : new Basket();

                workers[i] = new Worker(basket, taskPerWorker);

            }


            //var workers = from i in Enumerable.Range(0, workerCount)
            //              select new Worker(useSameBasketForAllWorker ? commonBasket : new Basket(), taskPerWorker);



            var result = PerformanceMeasure.InvokeTimed(() =>
             {

                //Step2. Start All Worker

                workers.ForEach(worker => worker.Start());

                //Step3. Wait for All workers to finish

                workers.ForEach(worker => worker.Wait());
                 return 0;

             });


            //Step4. Find the total items added by all workers and total time taken in step 2+3
            // Remebmer
            // if we use same baseket then total work done is Items in that single basket
            //else we need to sum all values from all baskets given to the workers.

            long totalItems=0;
            if (useSameBasketForAllWorker)
            {
                totalItems = commonBasket.Items;
            }
            else
            {
                workers.ForEach(worker => totalItems+=worker.Basket.Items);
            }

            Console.WriteLine($"totalItems: {totalItems}");
            Console.WriteLine($"Total time taken is :{result.TimeTaken.TotalMilliseconds} ms");

        }
    }
}
