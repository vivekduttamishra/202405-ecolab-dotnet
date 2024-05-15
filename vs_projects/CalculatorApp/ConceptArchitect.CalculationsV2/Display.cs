using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.CalculationsV2
{
    public abstract class Display
    {
        public abstract void Show(object output);
    }


    public class MonochromeDisplay: Display
    {
        public override void Show(object output)
        {
            Console.WriteLine(output);
        }
    }

    public class ColouredDisplay: Display
    {
        public ConsoleColor Color { get; set; } = ConsoleColor.Green;
        public override void Show(object output)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(output);
            Console.ResetColor();
        }
    }

   


    public class SimpleDisplay
    { 
        public static void Show(object output)
        {
            Console.WriteLine(output);
        }
    }

}
