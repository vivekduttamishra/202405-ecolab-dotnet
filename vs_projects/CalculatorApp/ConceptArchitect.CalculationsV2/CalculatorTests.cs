using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.CalculationsV2
{
    public class CalculatorTests
    {
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

                Result= result;
                return result.ToString();
            }
        }

        AdvancedCalculatorV2 calc;
        int x = 50;
        int y = 15;
        TestableFormatter formatter;

        [SetUp]
        public void SetUp() {
            
            formatter= new TestableFormatter();
            calc = new AdvancedCalculatorV2()
            {
                Formatter = formatter
            };
        }


        [Test]
        public void CalculatorGivesCorrectResultForValidOperator()
        {
            var expectedResult = new Plus().Calculate(x, y);

            calc.Execute(x, "plus", y);

            Assert.That(formatter.Result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CalculatorCallsFormatterForValidOperator()
        {
            var expectedResult = new Plus().Calculate(x, y);

            calc.Execute(x, "plus", y);

            Assert.That(formatter.CallCount, Is.EqualTo(1));
            Assert.That(formatter.OperatorName, Is.EqualTo("plus"));
        }

        [Test]
        public void CalculatorGivesErrorForInvalidOperator()
        {
            Assert.Fail("NOT YET IMPLEMENTED");
        }

        [Test]
        public void CalculatorDoesntCallFormatterForInvalidOperator()
        {
            calc.Execute(x, "invalid", y);

            Assert.That(formatter.CallCount, Is.EqualTo(0));
        }

        

        [Test]
        public void CalculatorCallsTheShowMethodOfTheProvidedDisplay()
        {
            Assert.Fail("NOT YET IMPLEMENTED");
        }
    }
}
