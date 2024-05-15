using ConceptArchitect.CalculationsV2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp02
{
    internal class SmartDisplay : Display
    {
        public ConsoleColor StandardColor { get; set; } = ConsoleColor.Yellow;
        public ConsoleColor ErrorColor { get; set; } = ConsoleColor.Red;

        public override void Show(object output)
        {
            if(output is ErrorInfo)
                Console.ForegroundColor = ErrorColor;
            else
                Console.ForegroundColor = StandardColor;

            Console.WriteLine(output);

            Console.ResetColor();
        }
    }
}
