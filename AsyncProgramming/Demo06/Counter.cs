using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo06
{
    public class Counter
    {
        public long Count { get; private set; }
        bool running = true;
        Thread thread;
        public string Name { get; set; }

        public Counter(string name, ThreadPriority priority=ThreadPriority.Normal)
        {
            thread = new Thread(Run);
            running = true;
            thread.Priority = priority;
            thread.Name = name;
            this.Name = name;
            thread.Start();
        }
        public void Run()
        {
            while (running)
                Count++;
        }

        public void Stop()
        {
            running = false;
        }

        internal void Wait()
        {
            if (thread.IsAlive)
                thread.Join();
        }
    }
}
