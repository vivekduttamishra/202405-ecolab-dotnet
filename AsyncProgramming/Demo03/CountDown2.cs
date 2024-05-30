using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo03
{
    internal class CountDown2
    {
        int max;
        public CountDown2(int max)
        {
            this.max = max;
        }

        public void CountDown()
        {
            

            var id = Thread.CurrentThread.ManagedThreadId;

            Console.WriteLine($"Thrad #{id}: starts");
            while (max >= 0)
            {
                Console.WriteLine($"Thrad#{id}: counts {max}");
                max--;
            }
            Console.WriteLine($"Thrad #{id}: stops");
        }
    }
}
