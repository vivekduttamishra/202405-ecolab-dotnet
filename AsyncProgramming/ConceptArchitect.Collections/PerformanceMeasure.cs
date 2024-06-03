using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Collections
{
    public class PerformanceResult<T>
    {
        public T ReturnValue { get; set; }
        public TimeSpan TimeTaken { get; set; }
    }

    public  class PerformanceMeasure
    {
        public static PerformanceResult<T> InvokeTimed<T>(Func<T> action)
        {
            var watch = new Stopwatch();
            watch.Start();
            var result=action();
            watch.Stop();
            return new PerformanceResult<T>
            {
                ReturnValue = result,
                TimeTaken = watch.Elapsed,

            };
        }
    
    
        public static PerformanceResult<bool> InvokeTimed<T>(Action action)
        {
            return InvokeTimed(() =>
            {
                action();
                return true;
            });
        }
    }
}
