using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo05
{
    public static class MathUtils
    {
        public static int Factorial(this int number)
        {
            int fn = 1;
            for(int i=1;i<=number;i++)
            {
                fn *= i;
                Thread.Sleep(1000);
            }
            return fn;
        }
    }
}
