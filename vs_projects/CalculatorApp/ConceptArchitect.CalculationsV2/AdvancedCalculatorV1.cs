using ConceptArchitect.Calculation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.CalculationsV2
{
    public class AdvancedCalculatorV1 : ICalculator
    {
        public AdvancedCalculatorV1()
        {
            AddOperator(new Plus());
            AddOperator(new Minus());
        }

        Dictionary<string,IOperator> operators = new Dictionary<string,IOperator>();

        public void AddOperator(IOperator oper, string oprName=null)
        {
            if(string.IsNullOrEmpty(oprName))
                oprName=oper.GetType().Name.ToLower();

            operators[oprName] = oper;
        }

        private IOperator SelectOperator(string oprName)
        {
            oprName=oprName.ToLower();
            if (operators.ContainsKey(oprName))
                return operators[oprName];
            else
                return null; //Not Found
        }
        public void Execute(int x, string oprName, int y)
        {
            //Step #1 calculate
            IOperator opr = SelectOperator(oprName);
            if(opr==null)
            {
                Console.WriteLine($"No such operator: '{oprName}'");
                return;
            }

            var result= opr.Calculate(x, y);



            //Step #2 Format the result
            var output = $"{x} {opr.GetType().Name} {y} = {result}";


            //Step #3 Presen the result
            Console.WriteLine(output);
        }

       
    }
}
