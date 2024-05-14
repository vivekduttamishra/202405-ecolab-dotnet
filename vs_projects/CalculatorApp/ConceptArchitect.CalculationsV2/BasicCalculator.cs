using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Calculation
{
    public class BasicCalculator : ICalculator
    {
        public void Execute(int x, string opr, int y)
        {
            //Step #1 calculate
            var result = 0;

            switch (opr)
            {
                case "plus":
                    result = x + y;
                    break;
                case "minus":
                    result = x - y;
                    break;
                case "multiply":
                    result = x * y;
                    break;
                case "divide":
                    result = x / y;
                    break;
                default:
                    Console.WriteLine($"Unsupported operation: '{opr}'");
                    return;
            }

            //Step #2 Format the result
            var output = $"{x} {opr} {y} = {result}";


            //Step #3 Presen the result
            Console.WriteLine(output);
        }
    }
}
