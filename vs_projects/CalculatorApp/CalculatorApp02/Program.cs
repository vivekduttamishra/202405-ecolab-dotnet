using ConceptArchitect.Calculation;
using ConceptArchitect.CalculationsV2;

namespace CalculatorApp02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICalculator calc = new BasicCalculator();

            UseCalculator(calc);


            //var calc2 = new AdvancedCalculatorV1();

            var calc2 = new AdvancedCalculatorV2();

            //calculator has a default display. we don't need to supply
            //calc2.Display = new MonochromeDisplay();


            UseCalculator(calc2);


            //we can inject (supply) new dependency
            //calc2.Display = new ColouredDisplay();

            calc2.Display = new SmartDisplay() 
            { 
                StandardColor = ConsoleColor.DarkCyan,
                 
            };

            calc2.AddOperator(new Multiply()); //can add additional operator without changing Calculator source code
            calc2.AddOperator(new Mod());

            UseCalculator(calc2);

        }

        private static void UseCalculator(ICalculator calc)
        {
            Console.WriteLine($"Testing {calc}");
            int x = 50, y = 15;
            calc.Execute(x, "plus", y);
            calc.Execute(x, "minus", y);
            calc.Execute(x, "multiply", y);
            calc.Execute(x, "divide", y);
            calc.Execute(x, "mod", y);

            Console.WriteLine("--------------\n");
        }
    }
}
