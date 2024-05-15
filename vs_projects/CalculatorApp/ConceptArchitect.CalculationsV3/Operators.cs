namespace ConceptArchitect.CalculationsV3
{
    //public interface Operator
    //{
    //    int Calculate(int x, int y);
    //}

    public delegate int Operator(int x, int y);

    class BasicOperators
    {
        public static int Plus(int x, int y) { return x + y; }
        public static int Minus(int x, int y) { return x - y; }
        public static int Multiply(int x, int y) { return x * y; }
        public static int Divide(int x, int y) { return x / y; }

    }
}