package demo.threading09.workerdemo2;

public class Basket {
	long items;

	
	public  void addItem(){
		
		//TODO: Add Lock
			long item=items;
			item++;
			items=item;
		
	}

	public long getItems() {
		return items;
	}

}
