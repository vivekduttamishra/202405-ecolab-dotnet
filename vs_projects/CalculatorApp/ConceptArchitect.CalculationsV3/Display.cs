namespace ConceptArchitect.CalculationsV3
{
    //public interface Display
    //{
    //    void Show(object value);
    //}

    public delegate void Display(object value);

    public class Displays
    { 
        public static void Monochrome(object value)
        {
            Console.WriteLine(value);
        }
    }

    public class SmartDisplay
    {
        public ConsoleColor StandardColor { get; set; } = ConsoleColor.Green;
        public ConsoleColor ErrorColor { get; set; }= ConsoleColor.Red;
    
        public void Print(object value)
        {
            ConsoleColor color = StandardColor;

            if(value is ErrorInfo)
                color = ErrorColor;

            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ResetColor();

        }
    }


}