package test.multithreading10.workerdemo01;

import java.util.concurrent.CountDownLatch;
import java.util.concurrent.CyclicBarrier;

import in.conceptarchitect.consoleapi.ConsoleInput;

public class Program {

	

	public static void main(String[] args) throws InterruptedException {
		// TODO Auto-generated method stub

		ConsoleInput input=new ConsoleInput();
		
		
		int workerCount=input.readInt("worker Counter?");
		int itemsToAdd=input.readInt("how many items each worker will add?");
		boolean separateBasket=input.readBoolean("Shall each worker use a separate basket? ");
		boolean lockRequired=input.readBoolean("lock required? ");
		
		CountDownLatch latch=new CountDownLatch(workerCount);
		
		Basket commonBasket=new Basket(lockRequired);
		Worker [] workers=new Worker[workerCount];
		System.out.println("creating workers...");
		for(int i=0;i<workerCount;i++){
			
			Basket basket= separateBasket? new Basket(lockRequired) : commonBasket;
			
			workers[i]=new Worker(basket,itemsToAdd,latch);
			
			
		}
	
		long startTime=System.currentTimeMillis();
		System.out.println("sending workers to work...");
		for(Worker worker:workers)
			worker.start();
		
		System.out.println("waiting for workers to finish...");
		
		latch.await(); //wiat till latch goes down to 0
		
		
		
		
		long endTime=System.currentTimeMillis();
		
		long totalItemsAdded=0;
		if(separateBasket){
			
			for(Worker worker:workers)
				totalItemsAdded+= worker.getBasket().getItems();
			
			
		}
		else
			totalItemsAdded=commonBasket.getItems();
		
		
		System.out.println("Total items added is "+totalItemsAdded);
		System.out.printf("Total time taken is %d ms\n",endTime-startTime);
	
	
	
	}

}
