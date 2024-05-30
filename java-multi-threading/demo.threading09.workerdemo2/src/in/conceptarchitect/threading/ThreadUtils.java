package in.conceptarchitect.threading;

public class ThreadUtils {

	public static void print(String fmt, Object ...params){
		
		String msg=String.format(fmt, params);
		
		System.out.printf("[#%d] %s\n",Thread.currentThread().getId(),msg);
		
	}
	
	public static void sleep(int ms){
		
		try{
			Thread.sleep(ms);
			
		}
		catch(InterruptedException ex){
			throw new ThreadInterruptedException(ex);
		}
		
	}
	
	
	public static void waitFor(Thread ...threads ){
		
		try{
			for(Thread thread :threads){
				thread.join();
			}
			
		}
		catch(InterruptedException ex){
			throw new ThreadInterruptedException(ex);
		}
		
	}

}
