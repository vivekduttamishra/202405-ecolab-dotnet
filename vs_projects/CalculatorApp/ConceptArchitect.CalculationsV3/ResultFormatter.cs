namespace ConceptArchitect.CalculationsV3
{
    //public interface ResultFormatter
    //{
    //    string Format(int value1, string operatorName, int value2, int result);
    //}

    public delegate string ResultFormatter(int value1, string operatorName, int value2, int result);

    public class Formatters
    { 
      
        public static string Infix(int value1, string operatorName, int value2, int result)
        {
            return $"{value1} {operatorName} {value2} = {result}";
        }

        public static string MethodStyle(int value1, string operatorName, int value2, int result)
        {
            return $"{operatorName}({value1} , {value2} = {result}";
        }
    }

}