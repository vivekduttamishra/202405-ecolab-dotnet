package test.multithreading17.executors;

import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;

import in.conceptarchitect.threading.ThreadUtils;

public class Program {

	

	public static void main(String[] args) throws InterruptedException {
		// TODO Auto-generated method stub

		ExecutorService executor=Executors.newFixedThreadPool(3);
		
		for(int i=0;i<10;i++) {
			final int id=i;
			
			executor.execute(() ->{
				int max=5;
				System.out.printf("[Thread #%d] [Task #%d] starts\n",Thread.currentThread().getId(),id);
				while(max>=0) {
					System.out.printf("[Thread #%d] [Task #%d] counts %d\n",Thread.currentThread().getId(),id,max);
					max--;
					ThreadUtils.sleep(1000);
				}
				System.out.printf("[Thread #%d] [Task #%d] ends\n",Thread.currentThread().getId(),id);
			});
		}
		
		executor.shutdown();
		executor.awaitTermination(1,TimeUnit.DAYS);
			
	}

}
