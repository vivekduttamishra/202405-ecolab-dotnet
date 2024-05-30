package demo.threading08.workerdemo;

import java.util.function.Function;

public class Executors {

	public  static <T> void executeAll( Task<T> task, T ... objects) {
	
		for(T object : objects)
			task.execute(object);
	}
	
	
}
