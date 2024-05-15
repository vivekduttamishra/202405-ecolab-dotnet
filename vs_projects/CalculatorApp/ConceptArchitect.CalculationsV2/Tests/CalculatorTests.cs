using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.CalculationsV2.Tests
{
    public class CalculatorTests
    {
        
        AdvancedCalculatorV2 calc;
        int x = 50;
        int y = 15;
        TestableFormatter formatter;

        [SetUp]
        public void SetUp()
        {

            formatter = new TestableFormatter();
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
            var display = new FakeTestableDisplay();
            calc.Display = display;

            calc.Execute(x, "invalid", y);

            Assert.That(display.Output, Is.InstanceOf<ErrorInfo>());
        }

        [Test]
        public void CalculatorIncludesInvalidOperatorNameInError()
        {
            var display = new FakeTestableDisplay();

            calc.Formatter = null; //dummy
            calc.Display = display; //fake

            string invalidOperator = "invalid";
            calc.Execute(x, invalidOperator, y);

            Assert.True( display.Output.ToString().Contains(invalidOperator));
        }

        [Test]
        public void CalculatorDoesntCallFormatterForInvalidOperator()
        {
            calc.Execute(x, "invalid", y);

            Assert.That(formatter.CallCount, Is.EqualTo(0));
        }



        [Test]
        public void CalculatorCallsTheShowMethodOfTheProvidedDisplayDuringSuccess()
        {
           var display= new FakeTestableDisplay();
            calc.Display = display;
            calc.Execute(x, "plus", y);

            Assert.That(display.CallCount, Is.EqualTo(1));
        }

        [Test]
        public void CalculatorCallsTheShowMethodOfTheProvidedDisplayDuringError()
        {
            var display = new FakeTestableDisplay();
            calc.Display = display;
            calc.Execute(x, "invalid", y);

            Assert.That(display.CallCount, Is.EqualTo(1));
        }
    }
}
