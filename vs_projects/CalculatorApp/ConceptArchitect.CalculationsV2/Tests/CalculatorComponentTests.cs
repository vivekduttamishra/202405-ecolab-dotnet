namespace ConceptArchitect.CalculationsV2.Tests
{
    public class CalculatorComponentTests
    {
        int value1 = 50;
        int value2 = 15;


        [Test]
        public void PlusOperatorAddsTheGivenValue()
        {
            var expectedResult = value1 + value2;
            var plus = new Plus();

            var actualResult = plus.Calculate(value1, value2);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void RawFormatterReturnsRawResult()
        {
            var expectedResult = 20;
            var formatter = new RawResultFormatter();

            var actualResult = formatter.Format(0, null, 0, expectedResult);

            Assert.That(actualResult, Is.EqualTo(expectedResult.ToString()));
        }

        [Test]
        public void MethodStyleResultFormatterFormatsResultProperly()
        {

            var a = 1;
            var b = 2;
            var opr = "something";
            var result = 100;

            var expectedResult = $"{opr}({a} , {b}) = {result}";

            var formatter = new MethodStyleResultFormatter();

            var actualResult = formatter.Format(a, opr, b, result);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [Ignore("Can't test console data or color using unit test")]
        public void MonchromeDisplayDisplaysInWhiteColour()
        {
            var display = new MonochromeDisplay();
            display.Show("hello world");

            //can't assert if it displayed hello world
            //can't assert if it is displayed in a given color
            //This is not the job of unit testing but UI testing
        }
    }
}