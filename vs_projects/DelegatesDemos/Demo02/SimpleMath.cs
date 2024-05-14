using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02
{
    class SimpleMath
    {
        public static int Plus(int x,int y) {  return x + y; }
        public static int Minus(int x, int y) { return x - y; }
    }

    class AdvancedMath
    {
        public int Multiply(int x, int y) { return x * y; }
        public int Divide(int x, int y) { return x / y; }
    }
}
