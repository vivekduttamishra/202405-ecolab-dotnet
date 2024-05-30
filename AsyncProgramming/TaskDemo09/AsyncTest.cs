using Demo07;
using System.Threading.Tasks;
using Xunit;

namespace TaskDemo09
{
    public class AsyncTest
    {
        [Fact]
        public void FactorialOf5Is120()
        {
            var f = MathUtils.Factorial(5);

            f.Wait();

            Assert.Equal(120, f.Result);


        }

        [Fact]
        public async Task Permutation5And3Is20()
        {
            var result = await MathUtils.Permutation(5, 3);

            Assert.Equal(60, result);
        }
    }
}




