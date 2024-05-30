package demo.threading09.workerdemo2;

import in.conceptarchitect.threading.ThreadUtils;

public class Worker implements Runnable {

	Thread thread;
	Basket basket;
	long itemsToAdd;
	
	public Worker(Basket basket,long itemsToAdd) {
		// TODO Auto-generated constructor stub
		this.basket=basket;
		thread=new Thread(this);
		this.itemsToAdd=itemsToAdd;
	}
	
	public void start(){
		thread.start();
	}
	
	public void waitFor(){
		ThreadUtils.waitFor(thread);
	}
	

	@Override
	public void run() {
		// TODO Auto-generated method stub
		for(int i=0;i<itemsToAdd;i++)
			basket.addItem();
	}

	public Basket getBasket() {
		return basket;
	}

	public void setBasket(Basket basket) {
		this.basket = basket;
	}

}
