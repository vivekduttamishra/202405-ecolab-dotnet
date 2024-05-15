using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.CalculationsV2.Tests
{
    internal class FakeTestableDisplay : Display
    {
        public object Output { get; set; }
        public int CallCount { get; set; }

        public override void Show(object output)
        {
            CallCount++;
            Output = output;
        }
    }
}
