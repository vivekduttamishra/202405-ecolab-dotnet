package demo.threading01.mainthread;

public class Program {


	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Thread thread=Thread.currentThread();
		System.out.println(thread);
		
		thread.setName("My Only Thread");
		thread.setPriority(Thread.MAX_PRIORITY);
		
		System.out.println(thread);
	}

}
