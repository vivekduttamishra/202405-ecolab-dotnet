package in.conceptarchitect.consoleutils;


public class Input{

	java.util.Scanner scanner=new java.util.Scanner(System.in);
	
	public int readInt(String prompt){
		System.out.print(prompt);
		return scanner.nextInt();
	}
	
	public String readString(String prompt){
		System.out.print(prompt);
		return scanner.next();
	}
	
	public double readDouble(String prompt){
		System.out.print(prompt);
		return scanner.nextDouble();
	}
	
	public boolean readBoolean(String prompt){
		System.out.print(prompt);
		return scanner.nextBoolean();
	}

}