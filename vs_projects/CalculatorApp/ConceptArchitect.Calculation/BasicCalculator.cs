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
            switch (opr)
            {
                case "plus":
                    Console.WriteLine($"{x} {opr} {y} = {x + y}");
                    break;
                case "minus":
                    Console.WriteLine($"{x} {opr} {y} = {x - y}");
                    break;
                case "multiply":
                    Console.WriteLine($"{x} {opr} {y} = {x * y}");
                    break;
                case "divide":
                    Console.WriteLine($"{x} {opr} {y} = {x / y}");
                    break;
                default:
                    Console.WriteLine($"Unsupported operation: '{opr}'");
                    break;
            }
        }
    }
}
