using System.Threading;
using Xunit;

namespace Demo02
{
    public class UnitTest1
    {
        [Fact]
        public void ThreadStartRunsTaskOnASeparateThread()
        {
            var currentThreadId = Thread.CurrentThread.ManagedThreadId;

            var t = new Thread(() =>
             {
                 Assert.NotEqual(currentThreadId, Thread.CurrentThread.ManagedThreadId);
             });

            t.Start();
        }
    }
}