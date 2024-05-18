using ConceptArchitect.Collections.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Collections.Tests
{
    internal class ExtensionMethodTests
    {
        DynamicArray<int> numbers;
        DblList<string> names;

        [SetUp]
        public void Setup()
        {
            numbers = new DynamicArray<int>(3);
            names = new DblList<string>();
        }

        [Test]
        public void CanAddManyItemsToDbList()
        {
            //SequenceUtils.AddMany(numbers, 1, 2, 3, 4);

            numbers.AddMany(1, 2, 3, 4);
            
            Assert.That(numbers.Count, Is.EqualTo(4));
        }

        [Test]
        public void CanAddManyItemsToDynamicArray()
        {
            //SequenceUtils.AddMany(names, "India","USA","France");

            names.AddMany("India", "USA", "France");
            
            Assert.That(names.Count, Is.EqualTo(3));
        }

        [Test]
        public void WeCanChainMethodCAlls()
        {
            var result = numbers
                                .AddMany(1, 2, 1, 1, 3, 4, 1)
                                .FindIndices(1)
                                .ToArray();


            Assert.That(result.Length, Is.EqualTo(4));
        }

    }
}
