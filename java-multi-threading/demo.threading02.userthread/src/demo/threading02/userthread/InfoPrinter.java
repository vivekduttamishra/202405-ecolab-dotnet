package demo.threading02.userthread;

public class InfoPrinter implements Runnable {

	
	@Override
	public void run() {
		// TODO Auto-generated method stub
		Thread thread=Thread.currentThread();
		System.out.printf("Thread [Name=%s\t Id=%d ]\n",thread.getName(),thread.getId());
	}

}
