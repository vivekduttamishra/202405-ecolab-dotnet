package demo.threading04.parameterizedcountdown;

public class Program {


	public static void main(String[] args) {
		// TODO Auto-generated method stub
		CountDownTask c1=new CountDownTask(200);
		
		CountDownTask c2=new CountDownTask(); //max=100
		
		Thread t1=new Thread(c1);
		Thread t2=new Thread(c2);
		
		t1.start();
		t2.start();
		
		System.out.println("end of main program");
	
	
	}

}
