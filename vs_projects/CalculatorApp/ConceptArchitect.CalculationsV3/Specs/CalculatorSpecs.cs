using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.CalculationsV3.Specs
{
    public class CalculatorSpecs
    {
        AdvancedCalculator calc;
        int operatorCount;
        int x = 5, y = 3;
        [SetUp]
        public void Setup()
        {
            calc = new AdvancedCalculator();
            operatorCount = calc.GetOperators().Count;
        }

        [Test]
        
        public void GetOperatorsReturnsAListOfSupportedOperationNames()
        {
            var result = calc.GetOperators();
            Assert.That(result, Is.InstanceOf<List<string>>());
        }

        [Test]

        public void HasOperatorReturnsTrueForValidOperator()
        {
            var oprName = "new_operator";
            calc.AddOperator(new Operator(BasicOperators.Plus), oprName);
            var operators = calc.GetOperators();
            Assert.True(calc.HasOperator(oprName));
        }

        [Test]

        public void HasOperatorReturnsFalseForInValidOperator()
        {
            Assert.False(calc.HasOperator("invalid"));
        }

        [Test]

        public void CalculatorHasADefaultDisplay()
        {
            Assert.That(calc.Display, Is.Not.Null);
            Assert.That(calc.Display, Is.InstanceOf<Display>());
        }

        [Test]

        public void CalculatorHasADefaultFormatter()
        {
            Assert.That(calc.Formatter, Is.Not.Null);
            Assert.That(calc.Formatter, Is.InstanceOf<ResultFormatter>());
        }

        int DummyOperator(int x,int y)
        {
            return 0;
        }

        [Test]

        public void AddOperatorCanAddNewOperatorWithOperationNameAsDefault()
        {
            calc.AddOperator(new Operator(DummyOperator));
            var operators= calc.GetOperators();
            Assert.That(operators.Count, Is.EqualTo(operatorCount+1));
            Assert.Contains("dummyoperator", operators);
        }

        [Test]

        public void AddOperatorCanAssignedACustomName()
        {
            calc.AddOperator(DummyOperator, "custom_name"); //autoboxed
            var operators= calc.GetOperators();
            Assert.Contains("custom_name", operators);  
        }

        [Test]

        public void ExecuteInvokesValidOperatorWhenPresent()
        {
            //Arrange
            var oprName = "xyz";
            bool called = false;
            Operator opr = (x, y) =>
            {
                called = true;
                return 0;
            };

            calc.AddOperator(opr, oprName);

            //ACT
            calc.Execute(x, oprName, y);

            //Assert
            Assert.That(called, Is.True);

        }

        [Test]

        public void ExecuteGetsValidResultForValidOperator()
        {
            //Arrange
            var oprName = "zero";
            var expectedResult = 100;
            Operator opr = (x, y) => expectedResult;
            calc.AddOperator(opr, oprName);


            //Assert
            calc.Formatter = (v1, opr, v2, result) =>
            {
                Assert.That(result, Is.EqualTo(expectedResult));
                return "";
            };


            //Act
            calc.Execute(x, oprName, y);

            
        }

        [Test]

        public void ExecuteDisplaysErrorInfoForInvalidOperator()
        {
            //Arrange for Assert
            calc.Display = output =>
            {
                Assert.That(output, Is.InstanceOf<ErrorInfo>());
            };

            //ACT
            calc.Execute(x, "invalid", y);
        }

        [Test]

        public void ExecuteDoesntCallFormatterForInvalidOperator()
        {
            //Arrange+Assert
            calc.Formatter = (v1, opr, v2, result) =>
            {
                Assert.Fail("Formatter Called");
                return null;
            };

            //Act
            calc.Execute(x, "invalid", y);
        }

        [Test]

        public void ExecutePassesOperatorNameToTheFormatter()
        {
            var executedOperatorName = "plus";

            calc.Formatter = (v1, opr, v2, result) =>
            {
                Assert.That(opr, Is.EqualTo(executedOperatorName));
                return null;
            };

            //Act
            calc.Execute(1, executedOperatorName, y);

        }

        [Test]

        public void ExecuteInvokesDisplayShowOnSuccess()
        {
            var displayCalled = false;
            calc.Display = output =>
            {
                displayCalled = true;
                Assert.That(output, Is.InstanceOf<string>());
            };
            var oprName = calc.GetOperators()[0];

            //act
            calc.Execute(1, oprName, 1);

            //Assert
            Assert.That(displayCalled, Is.True);

        }

        [Test]

        public void ExecuteInvokesDisplayShowOnFailure()
        {
            var displayCalled = false;
            calc.Display = output =>
            {
                displayCalled = true;
                Assert.That(output, Is.InstanceOf<ErrorInfo>());
            };
            var oprName = "invalid";

            //act
            calc.Execute(1, oprName, 1);

            //Assert
            Assert.That(displayCalled, Is.True);
        }
    }

    
}
