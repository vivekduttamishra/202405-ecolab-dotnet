using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo05
{
    public class PerformanceResult<T>
    {
        public T Result { get; set; }
        public TimeSpan TimeTaken { get; set; }
    }

    public  class PerformanceMeasure
    {
        public static PerformanceResult<T> MeasurePerformance<T>(Func<T> action)
        {
            var watch = new Stopwatch();
            watch.Start();
            var result=action();
            watch.Stop();
            return new PerformanceResult<T>
            {
                Result = result,
                TimeTaken = watch.Elapsed,

            };
        }
    }
}
