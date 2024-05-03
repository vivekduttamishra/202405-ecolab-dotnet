public class Permutation
{
	public static int Calculate(int n, int r)
	{
		return Math.Factorial(n)/Math.Factorial(n-r);
	}
}