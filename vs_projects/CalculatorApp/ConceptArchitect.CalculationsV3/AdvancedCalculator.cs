


using ConceptArchitect.CalculationsV3.Specs;

namespace ConceptArchitect.CalculationsV3
{
    public class AdvancedCalculator
    {
        public Display Display { get;  set; }
        public ResultFormatter Formatter { get;  set; }

        public AdvancedCalculator()
        {
            Display = Displays.Monochrome;
            Formatter = Formatters.Infix; //new ResultFormatter();
            AddOperator(BasicOperators.Plus);
            AddOperator(BasicOperators.Minus);
            AddOperator(BasicOperators.Multiply);
            AddOperator(BasicOperators.Divide);
        }

        public List<string> GetOperators()
        {
            return operators.Keys.ToList();
        }

        

        public bool HasOperator(string operatorName)
        {
            return operators.ContainsKey(operatorName);
        }
        Dictionary<string,Operator> operators=new Dictionary<string,Operator>();
        public void AddOperator(Operator _operator,string name=null)
        {
            if (string.IsNullOrEmpty(name))
                name = _operator.Method.Name; //_operator.ToString();
            name = name.ToLower();
            operators[name] = _operator;
           
        }

        public void Execute(int value1, string operatorName, int value2)
        {
            var _operator = SelectOperator(operatorName);
            if (_operator == null) 
            {
                Display(new ErrorInfo($"No such operator : '{operatorName}'"));
                return;
            }

            var result = _operator(value1, value2);

            var output = Formatter(value1, operatorName, value2, result);

            Display(output);
        }

        private Operator SelectOperator(string operatorName)
        {
            operatorName=operatorName.ToLower();
            if (operators.ContainsKey(operatorName))
                return operators[operatorName];
            else
                return null;
        }
    }
}