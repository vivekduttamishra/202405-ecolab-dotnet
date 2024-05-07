using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App03Tests
{
    public class SimpleMathTests
    {
        [Test]
        public void TestPlus()
        {
            var x = 50;
            var y = 15;
            var result = SimpleMath.Plus(x, y);
            if (result != x + y)
                throw new Exception("Plus Failed");
        }

        [Test]
        public void TestMinus()
        {
            var x = 50;
            var y = 15;
            var result = SimpleMath.Minus(x, y);
            if (result != x - y)
                throw new Exception($"Minus Failed expected {x-y} found {result}");
        }

        [Test]
        public void TestMultiply()
        {
            var x = 50;
            var y = 15;
            var result = SimpleMath.Multiply(x, y);
            Console.WriteLine($"Multiply({x},{y})={result}");

            if (result != x * y)
                Assert.Fail($"Multiply Failed. expected ={x * y}, found {result}");
        }

        [Test]
        public void TestDivide()
        {
            var x = 50;
            var y = 15;
            var result = SimpleMath.Divide(x, y);
            Console.WriteLine($"Divide({x},{y})={result}");

            Assert.True(result == x / y);
        }

        [Test]
        public void TestMod()
        {
            var x = 50;
            var y = 15;
            var result = SimpleMath.Mod(x, y);

            Assert.AreEqual(x % y, result);

           
        }

    }

}
