package demo.threading11.producerconsumer;

import java.lang.Thread.State;

import in.conceptarchitect.threading.ThreadUtils;

public class CountDownTask implements Runnable {

	int max;
	Thread thread;
	
	public CountDownTask(int max,boolean autoStart) {
		// TODO Auto-generated constructor stub
		this.max=max;
		
		thread=new Thread(this);
		if(autoStart)
			thread.start();
	}
	
	
	public CountDownTask(int max) {
		// TODO Auto-generated constructor stub
		this(max,true);
	}
	
	public Thread getThread(){return thread;}
	
	public void start(){
		if(thread.getState()==State.NEW)
			thread.start();
	}
	
	@Override
	public void run() {
		// TODO Auto-generated method stub
		Thread me=Thread.currentThread();
		//System.out.println("Thread #"+me.getId()+" starts...");
		ThreadUtils.print("starts");
		
		
		
		
		
		while(max>=0){
			
			ThreadUtils.print("counts %d", max);
			max--;
			
		}
		
		ThreadUtils.print("finishes...");
		
		

	}

}
