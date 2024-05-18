using ConceptArchitect.Collections.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Collections.Tests
{
    internal class SequenceUtilsTests
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
            SequenceUtils.AddMany(numbers, 1, 2, 3, 4);
            Assert.That(numbers.Count, Is.EqualTo(4));
        }

        [Test]
        public void CanAddManyItemsToDynamicArray()
        {
            SequenceUtils.AddMany(names, "India","USA","France");
            Assert.That(names.Count, Is.EqualTo(3));
        }

        [Test]
        public void FindIndicesReturnsSequenceOfMatchingIndices()
        {
            SequenceUtils.AddMany(numbers, 1, 2, 1, 1, 3, 4, 1);
            int[] valid1Indices = { 0, 2, 3, 6 };

            var result = SequenceUtils.FindIndices(numbers, 1);

            for(int i = 0;i<result.Count;i++)
                Assert.That(result[i], Is.EqualTo(valid1Indices[i]));
        }


        [Test]
        public void WeCanChainMethodCAlls()
        {
            var result =
                SequenceUtils.ToArray(
                        SequenceUtils.FindIndices(
                                 SequenceUtils.AddMany(numbers, 1, 2, 1, 1, 3, 4, 1
                                 ),
                                 1
                        )
                 );
                                

            Assert.That(result.Length, Is.EqualTo(4));
        }




    }
}
