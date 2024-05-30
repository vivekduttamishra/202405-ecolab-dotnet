package in.conceptarchitect.consoleapi;

public class ConsoleInput
{
	java.util.Scanner scanner=new java.util.Scanner(System.in);
	public String readString(String prompt)
	{
		System.out.print(prompt);
		return scanner.next();
		
	}

	public int readInt(String prompt)
	{
		System.out.print(prompt);
		return scanner.nextInt();
		
	}

	public double readDouble(String prompt)
	{
		System.out.print(prompt);
		return scanner.nextDouble();
		
	}
	public boolean readBoolean(String prompt)
	{
		System.out.print(prompt);
		return scanner.nextBoolean();
		
	}
}