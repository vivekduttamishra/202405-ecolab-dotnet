class Program
{
	static void Main()
	{
		int n=5;
		Program p=new Program();
		int fn = p.Factorial(5);
		System.Console.WriteLine("Factorial of "+n+" is "+fn);
	}

	int Factorial(int x)
	{
		if(x==1 || x==0)
			return 1;
		else
			return x*Factorial(x-1);
	}
}