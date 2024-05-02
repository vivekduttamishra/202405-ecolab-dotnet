public class Math
{

	public static int Factorial(int x)
	{
		if(x==1 || x==0)
			return 1;
		else
			return x*Factorial(x-1);
	}
}