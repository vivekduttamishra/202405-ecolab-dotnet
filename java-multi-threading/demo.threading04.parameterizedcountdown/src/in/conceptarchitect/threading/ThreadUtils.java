package in.conceptarchitect.threading;

public class ThreadUtils {

	public static void print(String fmt, Object ...params){
		
		String msg=String.format(fmt, params);
		
		System.out.printf("[#%d] %s\n",Thread.currentThread().getId(),msg);
		
	}

}
