using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Calculation
{
    public class BasicCalculatorV2 : ICalculator
    {
        public void Execute(int x, string opr, int y)
        {
            switch (opr)
            {
                case "plus":
                    Console.WriteLine($"{x} {opr} {y} = {Plus(x,y)}");
                    break;
                case "minus":
                    Console.WriteLine($"{x} {opr} {y} = {Minus(x,y)}");
                    break;
                case "multiply":
                    Console.WriteLine($"{x} {opr} {y} = {Multiply(x,y)}");
                    break;
                case "divide":
                    Console.WriteLine($"{x} {opr} {y} = {Divide(x,y)}");
                    break;
                default:
                    Console.WriteLine($"Unsupported operation: '{opr}'");
                    break;
            }
        }

        int Plus(int x, int y) { return x + y; }

        int Minus(int x,int y) { return x - y; }

        int Multiply(int x, int y) {  return x * y; }

        int Divide(int x, int y) { return x / y; }
    }
}
