using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDemo04
{
    public static class MathUtils
    {
        public static int Factorial(this int value)
        {
            int f = 1;
            for(int i=1;i<=value;i++)
            {
                f *= i;
                Thread.Sleep(1000);
            }

            return f;
        }
    }
}
