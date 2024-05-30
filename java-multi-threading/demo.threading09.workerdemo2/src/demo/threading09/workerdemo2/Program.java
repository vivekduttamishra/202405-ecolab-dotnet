package demo.threading09.workerdemo2;

import in.conceptarchitect.consoleutils.Input;

public class Program {


	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Input input=new Input();
		int workersCount=input.readInt("how many workers? ");
		int itemsToAdd=input.readInt("How many item each worker shall add ?" );
		boolean sameBasket=input.readBoolean("Use same basket for every one ? ");
		Basket singleBasket=new Basket();
		Worker [] workers=new Worker[workersCount];
		
		for(int i=0;i<workers.length;i++){
			
			Basket basket= sameBasket ? singleBasket : new Basket();
			
			Worker worker=new Worker(basket,itemsToAdd);
			
			workers[i]=worker;
			
		}
		System.out.println("starting workers...");
		for(int i=0;i<workers.length;i++)
			workers[i].start();
		
		System.out.println("waiting for workers to finish");
		for(Worker worker :workers)
			worker.waitFor();
		
		
		long totalItemsAdded=0;
		
		if(sameBasket)
			totalItemsAdded=singleBasket.getItems();
		else{
			
			for(Worker worker : workers)
				totalItemsAdded+=worker.getBasket().getItems();
			
		}
		
		System.out.println("Total items added is "+totalItemsAdded);
		
		
		
	
	}

}
