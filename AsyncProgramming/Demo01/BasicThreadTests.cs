using ConceptArchitect.Utils;
using System.Threading;
using Xunit;

namespace Demo01
{
    public class BasicThreadTests
    {
        [Fact]
        public void EveryAppRunsOnSomeThread()
        {
            var thread = Thread.CurrentThread;
            Assert.NotNull(thread);
        }

        [Fact]
        public void EveryThreadHasName()
        {
            var thread = Thread.CurrentThread;
            Assert.NotNull(thread.Name);
        }
    }
}










