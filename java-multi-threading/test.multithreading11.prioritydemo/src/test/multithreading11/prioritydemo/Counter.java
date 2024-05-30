package test.multithreading11.prioritydemo;

import in.conceptarchitect.threading.ThreadUtils;

public class Counter implements Runnable {

	Thread thread;
	long count;
	volatile boolean canRun;

	public long getCount() {		return count; 	}

	public void setCount(long count) {
		this.count = count;
	}
	
	public Counter(int priority) {
		// TODO Auto-generated constructor stub
		thread=new Thread(this);
		thread.setPriority(priority);
		thread.setDaemon(true);
	}
	
	public void start()
	{
		//ThreadUtils.println("starting thread");
		thread.start();
	}
	
	public void waitFor(){ ThreadUtils.waitFor(thread);}
	public void stop(){ canRun=false;}
	
	@Override
	public void run() {
		// TODO Auto-generated method stub
		canRun=true;
		ThreadUtils.println("starts...");
		
		while(canRun)
			count++;
		
		ThreadUtils.println("stops...");
		
	}

}
