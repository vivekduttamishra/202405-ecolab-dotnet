package demo.threading06.countdowntask;

public class Program {


	public static void main(String[] args) {
		// TODO Auto-generated method stub
		CountDownTask c1=new CountDownTask(200);		
		CountDownTask c2=new CountDownTask(100,false); //max=100
		CountDownTask c3=new CountDownTask(300);
		
		c2.start();
		c1.start();
		
		System.out.println("end of main program");
	
	
	}

}
