using ConceptArchitect.Utils;

namespace StackApp
{
    public class FixedStackSpecs
    {
        FixedSizedStack stack;
        [SetUp]
        public void Setup()
        {
            stack = new FixedSizedStack(3);
        }

        [Test]
        //[Ignore("Not Yet Implemented")]
        public void FixedStackShowBeInitializedWithAFixedSize()
        {
            var stack = new FixedSizedStack(5);

            Assert.IsNotNull(stack);
           
        }

        [Test]
        //[Ignore("Not Yet Implemented")]
        public void StackShouldBeInitiallyEmpty()
        {
           

            Assert.True(stack.IsEmpty);
        }

        [Test]
        //[Ignore("Not Yet Implemented")]
        public void StackCountShouldBeInitially0()
        {
            Assert.AreEqual(0, stack.Count);
        }

        [Test]
        //[Ignore("Not Yet Implemented")]
        public void SizeRefersToStackSize()
        {
            var size = 3;
            var stack = new FixedSizedStack(size);

            Assert.AreEqual(size, stack.Size);
        }

        [Test]
        //[Ignore("Not Yet Implemented")]
        public void PushToStackMakesStackNotEmpty()
        {
            //Act
            stack.Push(1);

            //Assert
            Assert.False(stack.IsEmpty);
        }

        [Test]
        //[Ignore("Not Yet Implemented")]
        public void PushToStackIncreasesStackCount()
        {
            stack.Push(1);
            stack.Push(2);

            Assert.AreEqual(2, stack.Count);

        }

        [Test]
        //[Ignore("Not Yet Implemented")]
        public void PushItemsEqualToStackSizeMakesItFull()
        {
            //act
            for(var i=0;i<stack.Size;i++)
                stack.Push(i);

            //assert
            Assert.IsTrue(stack.IsFull);
        }


        [Test]
        //[Ignore("Not Yet Implemented")]
        public void PushShouldSucceedForNonFullStack()
        {
            //Arrange
            for (var i = 0; i < stack.Size; i++)
            {
                var result=stack.Push(i);
                Assert.True(result);
            }
            
        }


        [Test]
        //[Ignore("Not Yet Implemented")]
        public void PushToAFullStackFails()
        {
            //Arrange
            for(var i=0;i<=stack.Size;i++)
                stack.Push(i);
            //Assume
            Assume.That(stack.IsFull, Is.True);

            //Act
            var result=stack.Push(100); //This should fail.

            //Assert ???
            Assert.False(result);

        }

        [Test]
        //[Ignore("Not Yet Implemented")]
        public void PopFromAStackDecreasesStackCount() {
            //Arrange
            stack.Push(1);
            stack.Push(2);
            var count= stack.Count;

            //Act
            int result;
            stack.Pop(out result);

            //Assert
            Assert.AreEqual(count - 1, stack.Count);


        }

        [Test]
        //[Ignore("Not Yet Implemented")]
        public void PopFromAFullStackMakesItNotFull()
        {
            //Arrange --> make it full first
            for (var i = 0; i < stack.Size; i++)
                stack.Push(i);

            //Assume
            Assume.That(stack.IsFull, Is.True);

            //Act
            int result;
            stack.Pop(out result);

            //Assert
            Assert.That(stack.IsFull, Is.False);

        }

        [Test]
        //[Ignore("Not Yet Implemented")]
        public void PopMakesStackEmptyWhenLastItemIsPopped()
        {
            //arrange
            stack.Push(1);
            //assume
            Assume.That(stack.IsEmpty, Is.False);

            //act
            int result;
            stack.Pop(out result);

            //assert
            Assert.That(stack.IsEmpty,Is.True);

        }

        [Test]
        //[Ignore("Not Yet Implemented")]
        public void PopFailsForEmptyStack()
        {
            //Assume
            Assume.That(stack.IsEmpty, Is.True);

            //Act
            int result;
           var success= stack.Pop(out result); //should fail

            //Assert?
            Assert.That(success, Is.False);
        }

        [Test]
        //[Ignore("Not Yet Implemented")]
        public void PopReturnsLastPushedItem()
        {
            //arrange
            var item = 10;
            stack.Push(item);

            //act
            int result;
            stack.Pop(out result); //how do I get item back?

            //Assert
            Assert.That(result, Is.EqualTo(item));
        }


        [Test]
        //[Ignore("Not Yet Implemented")]
        public void PopReturnsAllItemsInLIFO()
        {
            for (var i = 0; i < 3; i++)
                stack.Push(i);

            //ACT
            for(var i = 2; i >= 0; i--)
            {
                int result;
                stack.Pop(out result);
                Assert.That(result,Is.EqualTo(i));
            }

        }
    }
}