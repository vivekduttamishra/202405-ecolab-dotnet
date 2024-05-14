using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Calculation
{
    public class BasicCalculatorV3 : ICalculator
    {
        public void Execute(int x, string opr, int y)
        {
            if(opr=="plus")
            {
                var op = new Plus();
                op.Calculate(x, y);
            }
            else if (opr == "minus")
            {
                var op = new Minus();
                op.Calculate(x, y);
            }
            else if (opr == "multiply")
            {
                var op = new Multiply();
                op.Calculate(x, y);
            }
            else if (opr == "divide")
            {
                var op = new Divide();
                op.Calculate(x, y);
            }
            else
            {
                Console.WriteLine($"Invalid Operator: '{opr}'");
            }
        }

       
    }
}
