using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo07
{
    public class Worker
    {
        Thread thread;
        public Basket Basket { get; set; }

        public long TaskCount { get; set; }
        
        public Worker(Basket basket, long taskCount)
        {
            Basket= basket;
            TaskCount= taskCount;

            thread = new Thread(Work);

        }
        private void Work()
        {
            for (long i = 0; i < TaskCount; i++)
                Basket.AddItem();
        }

        public void Start()
        {
            thread.Start();
        }

        public void Wait()
        {
            if (thread.IsAlive)
                thread.Join();
        }
    }
}
