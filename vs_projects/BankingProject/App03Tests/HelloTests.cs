using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App03Tests
{
    public class HelloTests
    {
        [Test]
        public void Test1()
        {
            Console.WriteLine("I am Test 1");
        }

        [Test]
        public void Test2()
        {
            Console.WriteLine("I am Test 2");
        }

        public void Test3()
        {
            Console.WriteLine("I am Test 3");
        }

        [Test]
        public void NotATest()
        {
            Console.WriteLine("I am not a Test");
        }


    }
}
