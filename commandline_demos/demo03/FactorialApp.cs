class Program
{
	static void Main()
	{
		int n=5;
		int fn = Math.Factorial(5);

		System.Console.WriteLine($"Factorial of {n} is {fn}");

	}
}

class Math
{

	public static int Factorial(int x)
	{
		if(x==1 || x==0)
			return 1;
		else
			return x*Factorial(x-1);
	}
}