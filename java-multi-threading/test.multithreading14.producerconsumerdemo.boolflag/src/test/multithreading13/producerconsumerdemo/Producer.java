package test.multithreading13.producerconsumerdemo;

import in.conceptarchitect.threading.ThreadUtils;

public class Producer implements Runnable {

	Thread thread;
	volatile boolean canRun;
	private Stock stock;
	
	public Producer(Stock stock, int priority) {
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
			
			while(stock.isProduced() && canRun) //not yet consumed
				;
			stock.produce();
			stock.setProduced(true);
			
		}
	}

	public void start(){thread.start();}
	public void stop(){canRun=false;}
	public void waitFor(){ThreadUtils.waitFor(thread);}
	
}
