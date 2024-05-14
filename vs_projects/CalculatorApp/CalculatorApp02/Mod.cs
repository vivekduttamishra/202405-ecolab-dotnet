using ConceptArchitect.CalculationsV2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp02
{
    internal class Mod : IOperator
    {
        public int Calculate(int x, int y)
        {
            return x % y;
        }
    }
}
