using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Calculation
{
    public class BasicCalculatorV4 //: ICalculator
    {
        public void Execute(int x, IOperator opr, int y)
        {
           opr.Calculate(x, y);
        }

       
    }
}
