package demo.threading04.parameterizedcountdown;

import in.conceptarchitect.threading.ThreadUtils;

public class CountDownTask implements Runnable {

	int max;
	public CountDownTask(int max) {
		// TODO Auto-generated constructor stub
		this.max=max;
	}
	
	public CountDownTask(){ max=100;}

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
