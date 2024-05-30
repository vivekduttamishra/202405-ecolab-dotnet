package test.multithreading11.prioritydemo;

import in.conceptarchitect.consoleapi.ConsoleInput;
import in.conceptarchitect.threading.ThreadUtils;

public class Program {

	

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Thread.currentThread().setPriority(Thread.MAX_PRIORITY);
		
		ConsoleInput input=new ConsoleInput();
		System.out.println("You may want to change the affinity here!!!");
		int duration=input.readInt("duration (in seconds)  ? ");
		
		ThreadUtils.println("creating counters...");
		Counter slow=new Counter(Thread.NORM_PRIORITY-2);
		Counter fast=new Counter(Thread.NORM_PRIORITY+2);
		
		ThreadUtils.println("starting counters...");
		slow.start();
		fast.start();
		
		ThreadUtils.println("sleeping for "+duration+" seconds");
		ThreadUtils.sleep(duration*1000);
		
		ThreadUtils.println("stopping counters...");
		fast.stop();
		slow.stop();
		ThreadUtils.println("waiting for counters to stop...");
		
		fast.waitFor();
		slow.waitFor();
		
		System.out.println("Fast counts:"+fast.getCount());
		System.out.println("Slow coutns:"+slow.getCount());
		
		
		
		
	}

}
