using System.Threading;

namespace Demo05
{
    internal class Factorial
    {
        private int n;
        private Thread thread;

        private int result;
        public int Result
        {
            get
            {
                if (thread.IsAlive)
                    thread.Join();
                return result;
            }
        }
        public Factorial(int n)
        {
            this.n = n;
            thread = new Thread(Run);
            thread.Start();
        }

        private void Run()
        {
            int fn = 1;
            for (int i = 1; i <= n; i++)
            {
                fn *= i;
                Thread.Sleep(1000);
            }
            result = fn;
        }

        public void Wait()
        {
            thread.Join();
        }
        
    }
}