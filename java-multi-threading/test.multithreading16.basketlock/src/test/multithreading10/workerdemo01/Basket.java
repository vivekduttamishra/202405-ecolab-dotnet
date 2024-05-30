package test.multithreading10.workerdemo01;

import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;
import java.util.concurrent.locks.ReentrantReadWriteLock;

import in.conceptarchitect.threading.ThreadUtils;

public class Basket {

	long items;
	Lock lock;
	private boolean lockRequired;
	
	public Basket(boolean lockRequired){
		this.lockRequired=lockRequired;
		if(lockRequired)
			lock=new ReentrantLock();
	}
	
	

	public void addItem(){
	
		
		
		int attempt=0;
		try{
				
			
				if(lockRequired){
					
					while(attempt<3){
						if(lock.tryLock()){
							break;
						};
						attempt++;
						ThreadUtils.sleep(10);
					}
					if(attempt==3){
						System.out.print("X");
						return ;
					}
				}
				
				long x=items;
				x=x+1;
				items=x;
		}
		finally{
			if(lockRequired && attempt<3)
				lock.unlock();
		}
	}
	
	public long getItems() {
		return items;
	}

}
