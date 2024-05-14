using ConceptArchitect.CalculationsV2;
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
            //Step #1 calculate
            var result = opr.Calculate(x,y);

            

            //Step #2 Format the result
            var output = $"{x} {opr.GetType().Name} {y} = {result}";


            //Step #3 Presen the result
            Console.WriteLine(output);


        }
    }
}
