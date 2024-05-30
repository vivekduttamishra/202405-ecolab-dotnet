package demo.threading11.producerconsumer;

import in.conceptarchitect.threading.ThreadUtils;

public class Worker  {

	Stock stock;
	Action action;
	boolean run;
	
	public void stop() { run=false; }
	
	public Worker(Stock stock,Action action) {
		// TODO Auto-generated constructor stub
		this.stock=stock;
		this.action=action;
	}
	
	public void work() {
		run=true;
		
		while(run) {
		
			
			
		}
	}

}
