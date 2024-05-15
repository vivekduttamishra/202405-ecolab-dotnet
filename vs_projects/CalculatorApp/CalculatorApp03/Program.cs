using ConceptArchitect.CalculationsV3;

namespace CalculatorApp03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calc = new AdvancedCalculator();

            calc.Display = new SmartDisplay().Print;

            UseCalculator(calc);

            //anonymous delegate
            //Operator permutation = delegate (int n, int r)
            //{
            //    var fn = 1;
            //    for (var i = 1; i <= n; i++)
            //    {
            //        fn *= i;
            //    }

            //    var fn_r = 1;
            //    for (var i = 1; i <= n - r; i++)
            //    {
            //        fn_r *= i;
            //    }

            //    return fn / fn_r;
            //};

            Operator permutation =  (n, r) =>
            {
                var fn = 1;
                for (var i = 1; i <= n; i++)
                {
                    fn *= i;
                }

                var fn_r = 1;
                for (var i = 1; i <= n - r; i++)
                {
                    fn_r *= i;
                }

                return fn / fn_r;
            };

            Console.WriteLine(permutation.Method.Name);

            calc.AddOperator(permutation,"permutation");


            //Mod calculation

            //Operator mod = delegate(int x, int y) { return x % y; };
            
            //Operator power = delegate(int x, int y) {  return (int)Math.Pow(x,y); };

            Operator power =  (x, y) => (int)Math.Pow(x, y);

            calc.AddOperator(power, "power");

            calc.AddOperator(delegate (int x, int y) { return x % y; }, "mod");

            


            UseCalculator(calc);


        }

        

        private static void UseCalculator(AdvancedCalculator calc)
        {

            Console.WriteLine($"Using {calc}");
            int x = 5, y = 3;
            string[] operators = { "plus", "minus", "multiply", "divide", "mod", "power","permutation" };

            foreach(var opr in operators)
                calc.Execute(x, opr, y);

            Console.WriteLine("------------\n\n\n");

        }
    }
}
