using ConceptArchitect.Calculation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.CalculationsV2
{
    public class AdvancedCalculatorV2 : ICalculator
    {
        public Display Display { get; set; }

        public AdvancedCalculatorV2()
        {
            Display =new MonochromeDisplay(); //default dependency
            
            AddOperator(new Plus());
            AddOperator(new Minus());
        }

        public void Execute(int x, string oprName, int y)
        {
            //Step #1 calculate
            IOperator opr = SelectOperator(oprName);
            if (opr == null)
            {
                Display.Show(new ErrorInfo($"No such operator: '{oprName}'"));
                return;
            }

            var result = opr.Calculate(x, y);

            //Step #2 Format the result
            var output = $"{x} {opr.GetType().Name} {y} = {result}";


            //Step #3 Presen the result
            //Show(output);
            //SimpleDisplay.Show(output);
            Display.Show(output);
        }

        //private void Show(string output)
        //{
        //    Console.WriteLine(output)
        //}


       

        Dictionary<string, IOperator> operators = new Dictionary<string, IOperator>();

        public void AddOperator(IOperator oper, string oprName = null)
        {
            if (string.IsNullOrEmpty(oprName))
                oprName = oper.GetType().Name.ToLower();

            operators[oprName] = oper;
        }

        private IOperator SelectOperator(string oprName)
        {
            oprName = oprName.ToLower();
            if (operators.ContainsKey(oprName))
                return operators[oprName];
            else
                return null; //Not Found
        }
    }
}
