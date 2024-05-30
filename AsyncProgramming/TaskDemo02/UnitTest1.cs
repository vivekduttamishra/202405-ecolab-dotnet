using System;
using Xunit;

namespace TaskDemo02
{
    public class UnitTest1
    {
        Func<int> CreateIncrementor()
        {
            int i = 0;

            return () => ++i;
        }


        [Fact]
        public void MultipleCallsOfIncrementCanIncrementThe_i_ThatWasPresentInIncrementor()
        
        {
            var incr=CreateIncrementor();

            Assert.Equal(1, incr());
            Assert.Equal(2, incr());
        }

        [Fact]
        public void DifferentIncrementorWillHaveTheirOwnCopyOf_i_()
        {
            var incr1 = CreateIncrementor(); //both have different copy of i
            var incr2 = CreateIncrementor();

            Assert.Equal(1, incr1());
            Assert.Equal(2, incr1());

            Assert.Equal(1, incr2()); //incr2 agains increments from 0

            Assert.Equal(3, incr1()); //incr1 increments from where it left

        }
    }

    
}