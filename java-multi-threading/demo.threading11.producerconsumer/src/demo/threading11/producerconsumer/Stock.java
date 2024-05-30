package demo.threading11.producerconsumer;

public class Stock {
	long producedCount;
	long consumedCount;
	boolean produced;
	
	
	

	public  void produce(){
		
		if(!produced) {
			producedCount++;
			produced=true;
		}
		
	
	}
	
	
	public void consume() {
		if(produced) {
			consumedCount++;
			produced=false;
		}
	}


	public boolean isProduced() {return produced; }

	public long getProducedCount() {
		return producedCount;
	}



	public long getConsumedCount() {
		return consumedCount;
	}
	
	

}
