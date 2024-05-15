using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.CalculationsV2
{
    public interface IResultFormatter
    {
        string Format(int value1, string operatorName, int value2, int result);
    }

    public class InfixResultFormatter : IResultFormatter
    {
        public string Format(int value1, string operatorName,
                            int value2, int result)
        {
            return $"{value1} {operatorName} {value2} = {result}";
        }
    }

    public class RawResultFormatter : IResultFormatter
    {
        public string Format(int value1, string operatorName,
                            int value2, int result)
        {
            return $"{result}";
        }
    }

    public class MethodStyleResultFormatter : IResultFormatter
    {
        public string Format(int value1, string operatorName,
                            int value2, int result)
        {
            return $"{operatorName}({value1} , {value2}) = {result}";
        }
    }
}
