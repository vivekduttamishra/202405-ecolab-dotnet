package test.multithreading13.producerconsumerdemo;

import in.conceptarchitect.threading.ThreadUtils;

public class Consumer implements Runnable {

	Thread thread;
	volatile boolean canRun;
	private Stock stock;
	
	public Consumer(Stock stock, int priority) {
		// TODO Auto-generated constructor stub
		this.stock=stock;
		thread=new Thread(this);
		thread.setPriority(priority);
		
	}

	@Override
	public void run() {
		// TODO Auto-generated method stub
		canRun=true;
		while(canRun){
			stock.consume();
		}
	}

	public void start(){thread.start();}
	public void stop(){canRun=false;}
	public void waitFor(){ThreadUtils.waitFor(thread);}
	
}
