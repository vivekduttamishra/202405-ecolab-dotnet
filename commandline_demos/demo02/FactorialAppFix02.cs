class Program
{
	static void Main()
	{
		int n=5;
		int fn = Factorial(5);

		//System.Console.WriteLine("Factorial of "+n+" is "+fn);

		//System.Console.WriteLine("Factorial of {0} is {1}", n, fn);

		//System.Console.WriteLine($"Factorial of {n} is {fn}");

		System.Console.WriteLine($"Factorial of {n} is {Factorial(n)}");
	}

	static int Factorial(int x)
	{
		if(x==1 || x==0)
			return 1;
		else
			return x*Factorial(x-1);
	}
}