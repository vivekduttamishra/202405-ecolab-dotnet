namespace Demo02
{
    //delegate int PlusDelegate(int x, int y);

    delegate int BInaryOperator(int x, int y);
    internal class Program
    {
        static void Main(string[] args)
        {
            BInaryOperator add = SimpleMath.Plus;

            var result = add(10, 20);
            Console.WriteLine(result);

            BInaryOperator minus = SimpleMath.Minus;
            result= minus(10, 20);
            Console.WriteLine(result);

            var am = new AdvancedMath();
            BInaryOperator into = am.Multiply;
            result = into(5, 3);
            Console.WriteLine(result);
        }
    }
}
