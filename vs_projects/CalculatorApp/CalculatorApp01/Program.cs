using ConceptArchitect.Calculation;

namespace CalculatorApp01
{
    internal class Program
    {

        static void Main()
        {
            ExecuteCalculatorApp();
        }

        static void ExecuteCalculatorApp()
        {
            var calc = new BasicCalculatorV2();
            var kb = new Input();

            while (true)
            {
                var opr = kb.ReadString("operator?");

                if (opr=="quit")
                {
                    break;
                }

                var number1 = kb.ReadInt("Number1?");
                var number2 = kb.ReadInt("Number2?");
                calc.Execute(number1, opr, number2);
            }
        }

        static void UseCalculatorTest(string[] args)
        {
            var calc1 = new BasicCalculator();
            UseCalculator(calc1);
            
            
            var calc2 = new BasicCalculatorV2();
            UseCalculator(calc2);

            var calc3 = new BasicCalculatorV3();
            UseCalculator(calc3);

            var calc4= new BasicCalculatorV4();
            calc4.Execute(50, new Plus(), 15);
            calc4.Execute(50, new Multiply(), 15);
           // UseCalculator(calc4);
        }

        private static void UseCalculator(ICalculator calc)
        {
            Console.WriteLine($"Using Calculator {calc}");
            int x = 50, y = 15;

            calc.Execute(x, "plus", y);

            calc.Execute(x, "multiply", y);

            calc.Execute(x, "mod", y);

            Console.WriteLine("------------------\n\n");
        }

        //private static void UseCalculator(BasicCalculator calc)
        //{
        //    Console.WriteLine($"Using Calculator {calc}");
        //    int x = 50, y = 15;

        //    calc.Execute(x, "plus", y);

        //    calc.Execute(x, "multiply", y);

        //    calc.Execute(x, "mod", y);

        //    Console.WriteLine("------------------\n\n");
        //}

        //private static void UseCalculator(BasicCalculatorV2 calc)
        //{
        //    Console.WriteLine($"Using Calculator {calc}");
        //    int x = 50, y = 15;

        //    calc.Execute(x, "plus", y);

        //    calc.Execute(x, "multiply", y);

        //    calc.Execute(x, "mod", y);

        //    Console.WriteLine("------------------\n\n");
        //}
    }
}
