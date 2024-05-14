using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Calculation
{
    public interface IOperator
    {
        void Calculate(int x, int y);
    }

    public class Plus : IOperator
    {
        public void Calculate(int x, int y)
        {
            Console.WriteLine($"{x} plus {y} = {x + y}");
        }
    }

    public class Minus : IOperator
    {
        public void Calculate(int x, int y)
        {
            Console.WriteLine($"{x} minus {y} = {x - y}");
        }
    }

    public class Multiply : IOperator
    {
        public void Calculate(int x, int y)
        {
            Console.WriteLine($"{x} multiply {y} = {x * y}");
        }
    }

    public class Divide : IOperator
    {
        public void Calculate(int x, int y)
        {
            Console.WriteLine($"{x} divide {y} = {x / y}");
        }
    }

}
