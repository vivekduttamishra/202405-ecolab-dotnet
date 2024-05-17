using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConceptArchitect.Collections.Tests
{
    public class DynamicArrayTests
    {
        DynamicArray<int> array;
        int capacity = 3;

        [SetUp]
        public void DynamicArray()
        {
            array = new DynamicArray<int>(capacity); //capacity
        }

        [Test]
        public void DynamicArrayIsASequence()
        {
            Assert.That(array,Is.InstanceOf<ISequence<int>>());
        }

        [Test]
        public void DynamicArrayShouldBeIntializedWithCapacity()
        {
           Assert.That(array.Capacity, Is.EqualTo(capacity));
        }

        [Test]
        public void DynamicArrayShouldBeIntiallyHaveCount0()
        {
            Assert.That(array.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddIncreasesDynamicArrayCount()
        {
            var count = array.Count;
            array.Add(1);
            Assert.That(array.Count,Is.EqualTo(count+1));
        }

        [Test]
        public void AnArrayIsNotFullUntilCountEqualsCapacity()
        {
            array.Add(1);

            Assert.False(array.IsFull);
        }

        [Test]
        public void AnArrayBecomesFullWhenCountEqualsCapacity()
        {
            for (int i = 0;i<capacity;i++)
                array.Add(i);

            Assert.True(array.IsFull);
        }

        [Test]
        public void AddingItemToFullArrayExpandsCapciatyByFactorOfCapacity()
        {
            //Arrange
            for(int i=0;i<capacity;i++)
                array.Add(i);

            //Assume
            Assume.That(array.IsFull, Is.True);

            //Act
            array.Add(1);

            Assert.That(array.Capacity, Is.EqualTo(capacity*2));
            Assert.False(array.IsFull);
        }

        [Test]
        public void CanGetItemFromValidIndex()
        {
            array.Add(0);
            array.Add(1);
            for(int i=0;i<array.Count;i++)
                Assert.That(array[i], Is.EqualTo(i));
        }

        [Test]
        public void FailsToGetItemFromInvalidIndex()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                var x = array[0];
            });
            
        }
    }
}