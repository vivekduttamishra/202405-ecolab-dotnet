package test.multithreading18.futureandcallable;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;
import java.util.concurrent.TimeUnit;

public class Program {

	

	public static void main(String[] args) throws InterruptedException, ExecutionException {
		// TODO Auto-generated method stub

		ExecutorService executor=Executors.newFixedThreadPool(3);
		
		int [] ranges= {100000,50000,200000};
		
		List<Future<PrimeResult>> results=new  ArrayList<>();
		
		
		for(int max:ranges) {
			
			Future<PrimeResult> result= executor.submit(() -> countPrimes(2,max) );
			results.add(result);
			
		}
		
		System.out.println("waiting for responses");
		
		for(Future<PrimeResult> result :results)
			System.out.println(result.get());
		
		executor.shutdown();
		executor.awaitTermination(1,TimeUnit.DAYS);
			
	}
	
	static PrimeResult countPrimes(int min,int max) {
		PrimeResult result=new PrimeResult(min, max);
		for(int i=min;i<max;i++) {
			if(isPrime(i))
				result.addPrime();
			
		
		}
		return result;
	}

	private static boolean isPrime(int x) {
		// TODO Auto-generated method stub
		x=Math.abs(x);
		if(x<2)
			return false;
		
		for(int i=2;i<x;i++)
			if(x%i==0)
				return false;
		
		return true;
	}

}
