package test.multithreading19.computablefuture;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.concurrent.CompletableFuture;
import java.util.concurrent.ExecutionException;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.Future;
import java.util.concurrent.TimeUnit;

public class Program {

	

	public static void main(String[] args) throws InterruptedException, ExecutionException {
		// TODO Auto-generated method stub

		
		
		int [] ranges= {100000,50000,200000};
		
		List<Future<PrimeResult>> results=new  ArrayList<>();
		
		
		for(int max:ranges) {
			
			countPrimeAsync(2, max)
				.thenAccept(System.out::println);
			
		}
		
		System.out.println("waiting for responses");
		
		new Scanner(System.in).nextLine();
			
	}
	
	static CompletableFuture<PrimeResult> countPrimeAsync(final int min,final int max){
		
		return CompletableFuture.supplyAsync(()->countPrimes(min, max));
		
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
