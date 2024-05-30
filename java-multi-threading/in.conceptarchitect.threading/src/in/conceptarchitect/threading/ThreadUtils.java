package in.conceptarchitect.threading;

public class ThreadUtils {

	public static void print(String format, Object ...objects ){
		
		format="Thread #"+Thread.currentThread().getId()+":\t"+format;
		
		System.out.printf(format, objects);
		
	}
	
	public static void println(String format, Object ...objects){
		print(format+"\n",objects);
		
	}
	
	public static void print(Object o){
		print("%s", o);
	}
	
	public static void println(Object o){
		println("%s", o);
	}
	
	
	public static void sleep(int milliseconds){
		
		try {
			Thread.sleep(milliseconds);
		} 
		catch (InterruptedException e) {
			throw new ThreadInterruptedException(e.getMessage(), e);
		}
		
	}
	
	
	public static void waitFor(Thread ...threads){
		
		try{
			for(Thread thread:threads){
				thread.join();
			}
		}
		catch(InterruptedException ex){
			throw new ThreadInterruptedException(ex.getMessage(),ex);
		}
		
	}
	
	
	
}
