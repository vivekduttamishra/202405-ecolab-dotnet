using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.CalculationsV2.Tests
{

    //A Test Fake
    class TestableFormatter : IResultFormatter
    {
        public int Value1 { get; set; }
        public int Result { get; set; }
        public int Value2 { get; set; }
        public string OperatorName { get; set; }

        public int CallCount { get; set; }

        public string Format(int value1, string operatorName, int value2, int result)
        {
            Value1 = value1;
            Value2 = value2;
            OperatorName = operatorName;
            CallCount++;

            Result = result;
            return result.ToString();
        }
    }
}
