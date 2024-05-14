using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.CalculationsV2
{
    public interface IOperator
    {
        int Calculate(int x, int y);
    }

    public class Plus : IOperator
    {
        public int Calculate(int x, int y)
        {
            return x + y;
        }
    }

    public class Minus : IOperator
    {
        public int Calculate(int x, int y)
        {
            return x - y;
        }
    }

    public class Multiply : IOperator
    {
        public int Calculate(int x, int y)
        {
            return x * y;
        }
    }

    public class Divide : IOperator
    {
        public int Calculate(int x, int y)
        {
            return x / y;
        }
    }
}
